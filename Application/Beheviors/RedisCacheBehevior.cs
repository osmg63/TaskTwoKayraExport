﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.RedisCache;
using MediatR;

namespace Application.Beheviors
{
    public class RedisCacheBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService _redisCacheService;

        public RedisCacheBehevior(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is ICacheableQuery query)
            {
                var cacheKey=query.CacheKey;
                var cacheTime=query.CacheTime;

                var cachedData = await _redisCacheService.GetAsync<TResponse>(cacheKey);
                if(cachedData != null) 
                    return cachedData;

                var response = await next();

                if (response != null)
                    await _redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));
                

                return response;

            }
            return await next();
        }
    }
}
