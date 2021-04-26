using Miktobutik.Models;
using Miktobutik.Models.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace MikroButik.Data.Business
{
    public interface IRegister { }
    public interface ICRUDService : ICRUDService<object>
    {

    }

    /// <summary>
    /// DTO = Data Transfer Object
    /// DTO = Data Table Object
    /// 
    /// İnsert Update Delete için kullnılacak.
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public interface ICRUDService<TType> where TType : class
    {
        ResponseModel<TType> Add(TType entity);

        public ResponseModel<TType> Delete(TType entity);

        public ResponseModel<List<TType>> GetAll();

        ResponseModel<TType> Update(TType entity);

    }

    /// <summary>
    /// Filtreleme Özellikleri
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public interface IFiltered<TType> where TType : class
    {
        ResponseModel<List<TType>> Query(Expression<Func<TType, bool>> filter = null);
        ResponseModel<TType> GetById(long id);


    }

    public interface ILockable<TType> where TType : class
    {
        public bool Lock(object KeyValue);

    }
}
