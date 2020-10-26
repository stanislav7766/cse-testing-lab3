using System;
using System.IO;
using Xunit;

namespace IIG.Test.BinaryFlag
{
    public class UnitTest1
    {
        [Fact]
        public void TestConstructorTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2);
            bool actual = mbf.GetFlag();
            Assert.True(actual);
        }
        [Fact]
        public void TestConstructorFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);
            bool actual = mbf.GetFlag();
            Assert.False(actual);
        }
        [Fact]
        public void TestConstructorTooSmallLength()
        {
            try
            {
                IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1, false);
            }catch(Exception e)
            {
                bool actual = e.Message.Contains("Length of Flag must be bigger than one");

                Assert.True(actual);
            }
        }
        [Fact]
        public void TestConstructorTooBigLength()
        {
            try
            {
                IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(17179868705, false);
            }
            catch (Exception e)
            {
                bool actual = e.Message.Contains("Length of Flag must be lesser than '17179868704'");

                Assert.True(actual);
            }
        }
        [Fact]
        public void TestSetFlagReturnTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(20, false);
            for (ulong i = 0; i < 20; i++)
            {
                mbf.SetFlag(i);
            }
            bool actual = mbf.GetFlag();

            Assert.True(actual);
        }
        [Fact]
        public void TestSetFlagReturnFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(20, false);
            for (ulong i = 0; i < 10; i++)
            {
                mbf.SetFlag(i);
            }
            bool actual = mbf.GetFlag();
            Assert.False(actual);
        }
        [Fact]
        public void TestSetFlagExceedsLength()
        {
            try
            {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(20, false);
            mbf.SetFlag(21);
            }
            catch (Exception e)
            {
                bool actual = e.Message.Contains("Position must be lesser than length");
                Assert.True(actual);
            }
        }
        [Fact]
        public void TestResetFlagReturnFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(20, true);
            for (ulong i = 0; i < 20; i++)
            {
                mbf.ResetFlag(i);
            }
            bool actual = mbf.GetFlag();

            Assert.False(actual);
        }
        [Fact]
        public void TestResetFlagReturnFalse1()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(20, false);
            for (ulong i = 0; i < 10; i++)
            {
                mbf.ResetFlag(i);
            }
            bool actual = mbf.GetFlag();

            Assert.False(actual);
        }
        [Fact]
        public void TestResetFlagExceedsLength()
        {
            try
            {
                IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(20, false);
                mbf.ResetFlag(21);
            }
            catch (Exception e)
            {
                bool actual = e.Message.Contains("Position must be lesser than length");
                Assert.True(actual);
            }
        }     
    }
}
