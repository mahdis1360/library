using BusinessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using poco;
using Repository;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Create_Method()
        {
            //arrange
            BookPoco book = new BookPoco()
            {
                AutorId = Guid.NewGuid(),
                Description = "travel to Mexico",
                Title = "travel",
                Price = 20,
                Id = Guid.NewGuid()


            };

            Mock<IDataRepository<BookPoco>> mock = new Mock<IDataRepository<BookPoco>>();
            BookLogic logic = new BookLogic(mock.Object);

            try
            {
                logic.Add(book);

            }
            catch (Exception)
            {

                Assert.Fail("bad happen");
            }


        }

        [TestMethod]
        public void Test_Get_Method()
        {
            //arrange
            Guid id = Guid.NewGuid();
            Mock<IDataRepository<BookPoco>> mock = new Mock<IDataRepository<BookPoco>>();
            mock.Setup(repo => repo.Get(id)).Returns(
            new BookPoco()
            {
                AutorId = Guid.NewGuid(),
                Description = "travel to Mexico",
                Title = "travel",
                Price = 20,
                Id = id


            }); ;


            BookLogic logic = new BookLogic(mock.Object);
            //act
            BookPoco poco = logic.Get(id);
            //assert

            Assert.IsNotNull(logic);
            Assert.AreEqual("travel", poco.Title);


        }

        [TestMethod]
        public void Test_Update_Method()
        {
            //arrange

            Mock<IDataRepository<BookPoco>> mock = new Mock<IDataRepository<BookPoco>>();
            BookPoco book = new BookPoco()
            {
                AutorId = Guid.NewGuid(),
                Description = "travel to Mexico",
                Title = "travel",
                Price = 20,
                Id = Guid.NewGuid(),
            };

            BookLogic logic = new BookLogic(mock.Object);

            try
            {
                logic.Update(book);

            }
            catch (Exception)
            {

                Assert.Fail("bad happen");
            }
        }
        [TestMethod]
        public void Test_Search_Method()
        {
            //arrange
            string searchdetail = "travel to Mexico";
            Mock<IDataRepository<BookPoco>> mock = new Mock<IDataRepository<BookPoco>>();
            mock.Setup(repo => repo.GetList(searchdetail)).Returns(
            new BookPoco()
            {
                AutorId = Guid.NewGuid(),
                Description = "travel to Mexico",
                Title = "travel",
                Price = 20,
                Id = Guid.NewGuid(),


            });


            BookLogic logic = new BookLogic(mock.Object);
            //act
            BookPoco poco = logic.Search(searchdetail);
            //assert

            Assert.IsNotNull(logic);
            Assert.AreEqual("travel to Mexico", poco.Description);


        }




    }
}

