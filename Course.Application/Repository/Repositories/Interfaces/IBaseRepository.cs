﻿using Domain.Common;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Edit(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
