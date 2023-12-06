using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Repository.CustomModels;
using Repository.Interface;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.Interfaces;
using Method = System.Reflection.MethodBase;

namespace TiketAPI.Services
{
    public class BaseService<T> :  BaseParamEntity, IService<T> where T : class, new ()
    {
        protected readonly IConfiguration _config;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;
        protected readonly IRepository<T> _baseRepository; 
        protected BaseService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<T> baseRepository)
        {
            _config = config;
            _logger = logger;
            _mapper = mapper;
            _baseRepository = baseRepository;
        }
        public static string GetMethodName(StackTrace stackTrace)
        {
            return CommonFunc.GetMethodName(stackTrace);
        }
        public virtual async Task<ResponseService<T>> GetById(Guid id)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);

                T item = await _baseRepository.GetById(id);

                return new ResponseService<T>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<T>(ex.Message);
            }
        }
        public virtual async Task<ResponseService<V>> GetById<V>(Guid id)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);

                T item = await _baseRepository.GetById(id);

                return new ResponseService<T>(item).ConvertToResponse<T, V>(); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<V>(ex.Message);
            }
        }
        public virtual async Task<ResponseService<ListResult<T>>> GetListAsync(PagingParam param)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                ListResult<T> items = await _baseRepository.GetAll(param);
                return new ResponseService<ListResult<T>>(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<ListResult<T>>(ex.Message);
            }
        }
        public virtual async Task<ResponseService<ListResult<V>>> GetListAsync<V>(PagingParam param)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                ListResult<T> items = await _baseRepository.GetAll(param);
                return new ResponseService<ListResult<T>>(items).ConvertToResponse<T,V>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<ListResult<V>>(ex.Message);
            }
        }
        public virtual async Task<ResponseService<bool>> Delete(Guid id)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);

                await _baseRepository.Delete(id);

                return new ResponseService<bool>(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<bool>(ex.Message);
            }
        }
        public virtual async Task<ResponseService<T>> Update(Guid id,T item)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                item = CommonFunc.UpdateInfo<T>(item);
                await _baseRepository.Update(id, item);
                return new ResponseService<T>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<T>(ex.Message);
            }
        }
        public virtual async Task<ResponseService<V>> Update<V>(Guid id, Object item)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);

                T itemData = _mapper.Map<T>(item);
                itemData = CommonFunc.UpdateInfo<T>(itemData, false);

                await _baseRepository.Update(id, itemData);

                return new ResponseService<T>(itemData).ConvertToResponse<T, V>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<V>(ex.Message);
            }
        }
        public virtual async Task<ResponseService<T>> Create(T item)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);
                item = CommonFunc.UpdateInfo<T>(item);
                await _baseRepository.Create(item);
                return new ResponseService<T>(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<T>(ex.Message);
            }
        }
        public virtual async Task<ResponseService<V>> Create<V>(Object item)
        {
            try
            {
                _logger.LogInfo(Method.GetCurrentMethod().Name);

                T itemData = _mapper.Map<T>(item);
                itemData = CommonFunc.UpdateInfo<T>(itemData);

                await _baseRepository.Create(itemData);

                return new ResponseService<T>(itemData).ConvertToResponse<T, V>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<V>(ex.Message);
            }
        }
    }
}
