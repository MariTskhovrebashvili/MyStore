using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using Store.Repositories;
using Store.Models;
using Xunit;

namespace Test.Repository
{
    public abstract class BaseRepositoryTest<TRepo, TModel> where TModel : BaseModel<int>, new() where TRepo : BaseRepository<TModel, int>
    {
        private readonly TRepo _repository;

        protected BaseRepositoryTest(TRepo repository)
        {
            _repository = repository;
        }
        
        [NUnit.Framework.Theory]
        public virtual void InsertTest(TModel model)
        {
            int returnedValue = _repository.Insert(model);
            
            Assert.NotZero(returnedValue);
        }

        [NUnit.Framework.Theory]
        public void GetTest(TModel model)
        {
            TModel returnedModel = _repository.Get(model.Id);

            Assert.AreEqual(model.Id, returnedModel.Id);
        }

        [Test]
        public void SelectTest()
        {
            var result = _repository.Select();
            
            Assert.NotZero(result.Count());
        }

        [NUnit.Framework.Theory]
        public void UpdateTest(TModel newModel)
        {
            _repository.Update(newModel);
            Assert.IsTrue(true);
        }
    }
}