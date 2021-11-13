﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Database
{
    public abstract class BaseRepository<Entity>: IRepository<Entity> where Entity: BaseEntity
    {
        protected MyDoctorAppDbContext mDbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(MyDoctorAppDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
                list.Add(entity);
            return list;
        }

        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);
            return SaveChanges();
        }

        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return SaveChanges();
            }
            return false;

        }

        public bool SaveChanges()
        {
           return mDbContext.SaveChanges() > 0;
        }
    }
}
