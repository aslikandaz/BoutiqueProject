using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess
{
    //generic constraint (generic kısıt)
    // class: referans tip olabilir demek
    // IEntity: IEntity olabilir veya IEntity  implemete eden bir nesne olabilir
    // new(): newlenebilir olmalı (yani IEntity olamaz artık)
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T GetById(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // parantez içi filre verirse ona göre elemanları getir vermezse hepsini getir demek
        T Get(Expression<Func<T, bool>>filter);// burada da filtre zorunlu kılındı
        void Add(T entity);
        void Update(T entitiy);
        void Delete(T entity);
        
    }
}
