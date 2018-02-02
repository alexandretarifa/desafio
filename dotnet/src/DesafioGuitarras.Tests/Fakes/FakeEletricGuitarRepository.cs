using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DesafioGuitarras.Tests.Fakes
{
    public class FakeEletricGuitarRepository : IEletricGuitarRepository
    {
        public List<EletricGuitar> Guitars;
        public FakeEletricGuitarRepository()
        {
            Guitars = new List<EletricGuitar>()
            {
                new EletricGuitar()
                {
                    Id = 1,
                    Name = "PRS Custom",
                    Description = "Description PRS Custom",
                    ImageUrl = "http://www.prsguitars.com/images/electrics/floydcustom24_straight1.png",
                    Price = 9000,
                    InsertDate = DateTime.Now
                },
                new EletricGuitar()
                {
                    Id = 2,
                    Name = "PRS Specialty",
                    Description = "Description PRS Specialty",
                    ImageUrl = "http://www.prsguitars.com/images/electrics/509_2017_straight1.jpg",
                    Price = 9000,
                    InsertDate = DateTime.Now
                },
                new EletricGuitar()
                {
                    Id = 3,
                    Name = "PRS Hollowbody",
                    Description = "Description PRS Hollowbody",
                    ImageUrl = "http://www.prsguitars.com/images/electrics/hollowbody12_straight1.png",
                    Price = 9000,
                    InsertDate = DateTime.Now
                },
            };
        }

        public EletricGuitar Add(EletricGuitar entity)
        {
            Guitars.Add(entity);
            return entity;
        }

        public IEnumerable<EletricGuitar> Add(IEnumerable<EletricGuitar> entities)
        {
            foreach (var entity in entities)
                Add(entity);

            return entities;
        }

        public bool Delete(EletricGuitar entity)
        {
            Guitars.Remove(entity);
            return true;
        }

        public void Delete(IEnumerable<EletricGuitar> entities)
        {
            foreach (var entity in entities)
                Delete(entity);
        }

        public void Dispose()
        {
            Guitars.Clear();
        }

        public EletricGuitar Edit(EletricGuitar entity)
        {
            var guitar = Guitars.FirstOrDefault(x => x.Id == entity.Id);
            guitar.Name = entity.Name;
            guitar.Description = entity.Description;
            guitar.ImageUrl = entity.ImageUrl;
            guitar.Price = entity.Price;
            guitar.Validation = entity.Validation; //keep tracking
            return guitar;
        }

        public IEnumerable<EletricGuitar> Edit(IEnumerable<EletricGuitar> entities)
        {
            foreach (var entity in entities)
                Edit(entity);

            return entities;
        }

        public EletricGuitar Find(Expression<Func<EletricGuitar, bool>> predicate) => GetAll().FirstOrDefault(predicate);

        public IQueryable<EletricGuitar> GetAll() => Guitars.AsQueryable();

        public EletricGuitar GetByPrimaryKey(object id)
        {
            if (!id.GetType().Equals(typeof(int)))
                return null;

            return Guitars.FirstOrDefault(x => x.Id == (int)id);
        }

        public int Save() => Guitars.Count;
    }
}
