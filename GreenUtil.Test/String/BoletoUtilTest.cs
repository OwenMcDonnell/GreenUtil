﻿using GreenUtil.String;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GreenUtil.Test.String
{

    /// <summary>
    /// Testes da classe <see cref="BoletoUtil"/>
    /// </summary>
    [TestClass]
    public class BoletoUtilTest
    {

        [TestMethod]
        public void WhenNullLinhaDigitavelThenShouldThrowArgumentNullException()
        {
            //Act
            Assert.ThrowsException<ArgumentNullException>(() => BoletoUtil.ValidateBoleto(null));
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("23790213029000000428411006937707174710000196224")]
        [DataRow("34191573874418700909531333130008675400000054075")]
        [DataRow("23792373049171089594630038894207172520000353362")]
        [DataRow("23790328049137172013697007987601772540000755900")]
        [DataRow("23790328049137188014611007987602172750000807523")]
        [DataRow("23790328049137178014800007987605372610000493705")]
        [DataRow("03399473763420000090856868001019972510000005954")]
        [DataRow("23793397042000000962910002439007172530000006551")]
        [DataRow("23792897019100000117111001633004175140000051280")]
        [DataRow("23792897019100000117116001633003275140000023040")]
        [DataRow("23792897019100000117121001633003175140000042940")]
        [DataRow("23793135019000000053064003000003275180000039200")]
        [DataRow("03399716324440600000802379301019375180000018028")]
        [DataRow("03399716324440600000802380701017175180000170890")]
        [DataRow("03399716324440600000802404801017275180000124752")]
        [DataRow("34191097761033081293382951080009175160000131166")]
        [DataRow("34191097761039427293382951080009475230000052164")]
        [DataRow("34191097761041357293382951080009475270000010546")]
        [DataRow("34191091070491363028304107700009175170000224710")]
        [DataRow("34191090080071223324660375390006475180000016006")]

        public void WhenValidLinhaDigitavelWithoutMaskThenShouldReturnTrue(string boleto)
        {
            //Act
            bool result = BoletoUtil.ValidateBoleto(boleto);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("23790.21302 90000.004284 11006.937707 1 74710000196224")]
        [DataRow("34191.57387 44187.009095 31333.130008 6 75400000054075")]
        [DataRow("23792.37304 91710.895946 30038.894207 1 72520000353362")]
        [DataRow("23790.32804 91371.720136 97007.987601 7 72540000755900")]
        [DataRow("23790.32804 91371.880146 11007.987602 1 72750000807523")]
        [DataRow("23790.32804 91371.780148 00007.987605 3 72610000493705")]
        [DataRow("03399.47376 34200.000908 56868.001019 9 72510000005954")]
        [DataRow("23793.39704 20000.009629 10002.439007 1 72530000006551")]
        [DataRow("34191.09776 10413.572933 82951.080009 4 75270000010546")]
        [DataRow("23792.89701 91000.001171 11001.633004 1 75140000051280")]
        [DataRow("23792.89701 91000.001171 16001.633003 2 75140000023040")]
        [DataRow("23792.89701 91000.001171 21001.633003 1 75140000042940")]
        [DataRow("23793.13501 90000.000530 64003.000003 2 75180000039200")]
        [DataRow("03399.71632 44406.000008 02379.301019 3 75180000018028")]
        [DataRow("03399.71632 44406.000008 02380.701017 1 75180000170890")]
        [DataRow("03399.71632 44406.000008 02404.801017 2 75180000124752")]
        [DataRow("34191.09776 10330.812933 82951.080009 1 75160000131166")]
        [DataRow("34191.09776 10394.272933 82951.080009 4 75230000052164")]
        [DataRow("34191.09776 10413.322933 82951.080009 1 75270000011718")]
        [DataRow("34191.09776 10413.572933 82951.080009 4 75270000010546")]
        [DataRow("34191.09107 04913.630283 04107.700009 1 75170000224710")]
        [DataRow("34191.09008 00712.233246 60375.390006 4 75180000016006")]
        public void WhenValidLinhaDigitavelWithMaskThenShouldReturnTrue(string boleto)
        {
            //Act
            bool result = BoletoUtil.ValidateBoleto(boleto);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenLinhaDigitavelLengthIsLessThan47CharThenShouldReturnFalse()
        {
            //Arrange
            var linhaDigitavel = "123456789";

            //Act
            bool result = BoletoUtil.ValidateBoleto(linhaDigitavel);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenLinhaDigitavelLengthIsGreaterThan47CharThenShouldReturnFalse()
        {
            //Arrange
            var linhaDigitavel = new string('0', 48); ;

            //Act
            bool result = BoletoUtil.ValidateBoleto(linhaDigitavel);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("23790213029000000428411006937707174710000196229")]
        [DataRow("34191573874418700909531333130008675400000054072")]
        [DataRow("23792373049171089594630038894207172520000353363")]
        [DataRow("23790328049137172013697007987601772540000755904")]
        [DataRow("23790328049137188014611007987602172750000807525")]
        [DataRow("23790328049137178014800007987605372610000493706")]
        [DataRow("03399473763420000090856868001019972510000005957")]
        [DataRow("23793397042000000962910002439007172530000006558")]
        [DataRow("23792897019100000117111001633004175140000051289")]
        [DataRow("23792897019100000117116001633003275140000023041")]
        [DataRow("23792897019100000117121001633003175140000042942")]
        [DataRow("23793135019000000053064003000003275180000039203")]
        [DataRow("03399716324440600000802379301019375180000018024")]
        [DataRow("03399716324440600000802380701017175180000170895")]
        [DataRow("03399716324440600000802404801017275180000124756")]
        [DataRow("34191097761033081293382951080009175160000131167")]
        [DataRow("34191097761039427293382951080009475230000052168")]
        [DataRow("34191097761041357293382951080009475270000010549")]
        [DataRow("34191091070491363028304107700009175170000224711")]
        [DataRow("34191090080071223324660375390006475180000016002")]
        [DataRow("34191090080071223324660375390006475180202011302")]
        [DataRow("11111111111111111111111111111111111111111111111")]
        [DataRow("22222222222222222222222222222222222222222222222")]
        [DataRow("33333333333333333333333333333333333333333333333")]
        [DataRow("44444444444444444444444444444444444444444444444")]
        [DataRow("55555555555555555555555555555555555555555555555")]
        [DataRow("66666666666666666666666666666666666666666666666")]
        [DataRow("77777777777777777777777777777777777777777777777")]
        [DataRow("88888888888888888888888888888888888888888888888")]
        [DataRow("99999999999999999999999999999999999999999999999")]
        [DataRow("00000000000000000000000000000000000000000000000")]
        [DataRow("34191090080071223324660375330106475110000116005")]
        public void WhenLinhaDigitavelIsInvalidWithoutMaskThenShouldReturnFalse(string linhaDigitavel)
        {
            //Act
            bool result = BoletoUtil.ValidateBoleto(linhaDigitavel);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("23790.21302 90000.004284 11006.937707 1 74710000196229")]
        [DataRow("34191.57387 44187.009095 31333.130008 6 75400000054072")]
        [DataRow("23792.37304 91710.895946 30038.894207 1 72520000353363")]
        [DataRow("23790.32804 91371.720136 97007.987601 7 72540000755904")]
        [DataRow("23790.32804 91371.880146 11007.987602 1 72750000807525")]
        [DataRow("23790.32804 91371.780148 00007.987605 3 72610000493706")]
        [DataRow("03399.47376 34200.000908 56868.001019 9 72510000005957")]
        [DataRow("23793.39704 20000.009629 10002.439007 1 72530000006558")]
        [DataRow("23792.89701 91000.001171 11001.633004 1 75140000051289")]
        [DataRow("23792.89701 91000.001171 16001.633003 2 75140000023041")]
        [DataRow("23792.89701 91000.001171 21001.633003 1 75140000042942")]
        [DataRow("23793.13501 90000.000530 64003.000003 2 75180000039203")]
        [DataRow("03399.71632 44406.000008 02379.301019 3 75180000018024")]
        [DataRow("03399.71632 44406.000008 02380.701017 1 75180000170895")]
        [DataRow("03399.71632 44406.000008 02404.801017 2 75180000124756")]
        [DataRow("34191.09776 10330.812933 82951.080009 1 75160000131167")]
        [DataRow("34191.09776 10394.272933 82951.080009 4 75230000052168")]
        [DataRow("34191.09776 10413.572933 82951.080009 4 75270000010549")]
        [DataRow("34191.09107 04913.630283 04107.700009 1 75170000224711")]
        [DataRow("34191.09008 00712.233246 60375.390006 4 75180000016002")]
        [DataRow("11111.11111 11111.111111 11111.111111 1 11111111111111")]
        [DataRow("22222.22222 22222.222222 22222.222222 2 22222222222222")]
        [DataRow("33333.33333 33333.333333 33333.333333 3 33333333333333")]
        [DataRow("44444.44444 44444.444444 44444.444444 4 44444444444444")]
        [DataRow("55555.55555 55555.555555 55555.555555 5 55555555555555")]
        [DataRow("66666.66666 66666.666666 66666.666666 6 66666666666666")]
        [DataRow("77777.77777 77777.777777 77777.777777 7 77777777777777")]
        [DataRow("88888.88888 88888.888888 88888.888888 8 88888888888888")]
        [DataRow("99999.99999 99999.999999 99999.999999 9 99999999999999")]
        [DataRow("00000.00000 00000.000000 00000.000000 0 00000000000000")]
        public void WhenLinhaDigitavelIsInvalidWithMaskThenShouldReturnFalse(string linhaDigitavel)
        {
            //Act
            bool result = BoletoUtil.ValidateBoleto(linhaDigitavel);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenLinhaDigitavelIsNullThenGenerateBarCodeTextShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => BoletoUtil.GenerateBarCodeText(null));
        }

        [TestMethod]
        public void WhenLinhaDigitavelLengthIsGreaterThan47ThenGenerateBarCodeTextShouldThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BoletoUtil.GenerateBarCodeText(new string('0', 48)));
        }

        [TestMethod]
        public void WhenLinhaDigitavelLengthIsLessThan47ThenGenerateBarCodeTextShouldThrowArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BoletoUtil.GenerateBarCodeText("1234567890"));
        }

        [TestMethod]
        public void WhenLinhaDigitavelIsNullThenValidateMaskShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => BoletoUtil.ValidateMask(null));
        }

        [DataTestMethod]
        [DataRow("23790.21302 90000.004284 11006.937707 1 74710000196229")]
        [DataRow("34191.57387 44187.009095 31333.130008 6 75400000054072")]
        [DataRow("23792.37304 91710.895946 30038.894207 1 72520000353363")]
        [DataRow("23790.32804 91371.720136 97007.987601 7 72540000755904")]
        [DataRow("23790.32804 91371.880146 11007.987602 1 72750000807525")]
        [DataRow("23790.32804 91371.780148 00007.987605 3 72610000493706")]
        [DataRow("03399.47376 34200.000908 56868.001019 9 72510000005957")]
        [DataRow("23793.39704 20000.009629 10002.439007 1 72530000006558")]
        [DataRow("23792.89701 91000.001171 11001.633004 1 75140000051289")]
        [DataRow("23792.89701 91000.001171 16001.633003 2 75140000023041")]
        [DataRow("23792.89701 91000.001171 21001.633003 1 75140000042942")]
        [DataRow("23793.13501 90000.000530 64003.000003 2 75180000039203")]
        [DataRow("03399.71632 44406.000008 02379.301019 3 75180000018024")]
        [DataRow("03399.71632 44406.000008 02380.701017 1 75180000170895")]
        [DataRow("03399.71632 44406.000008 02404.801017 2 75180000124756")]
        [DataRow("34191.09776 10330.812933 82951.080009 1 75160000131167")]
        [DataRow("34191.09776 10394.272933 82951.080009 4 75230000052168")]
        [DataRow("34191.09776 10413.572933 82951.080009 4 75270000010549")]
        [DataRow("34191.09107 04913.630283 04107.700009 1 75170000224711")]
        [DataRow("34191.09008 00712.233246 60375.390006 4 75180000016002")]
        [DataRow("11111.11111 11111.111111 11111.111111 1 11111111111111")]
        [DataRow("22222.22222 22222.222222 22222.222222 2 22222222222222")]
        [DataRow("33333.33333 33333.333333 33333.333333 3 33333333333333")]
        [DataRow("44444.44444 44444.444444 44444.444444 4 44444444444444")]
        [DataRow("55555.55555 55555.555555 55555.555555 5 55555555555555")]
        [DataRow("66666.66666 66666.666666 66666.666666 6 66666666666666")]
        [DataRow("77777.77777 77777.777777 77777.777777 7 77777777777777")]
        [DataRow("88888.88888 88888.888888 88888.888888 8 88888888888888")]
        [DataRow("99999.99999 99999.999999 99999.999999 9 99999999999999")]
        [DataRow("00000.00000 00000.000000 00000.000000 0 00000000000000")]
        public void WhenLinhaDigitavelMaskIsValidThenValidateMaskShouldReturnTrue(string mask)
        {
            //Act
            bool validMask = BoletoUtil.ValidateMask(mask);

            Assert.IsTrue(validMask);
        }

        [DataTestMethod]
        [DataRow("00000 00000 00000 000000 00000 000000 0 00000000000000")]
        [DataRow("00000.00000.00000.000000.00000.000000.0.00000000000000")]
        [DataRow("00000000000000000000000000000000000000000000000")]
        [DataRow("")]
        [DataRow("0")]
        public void WhenLinhaDigitavelMaskIsInValidThenValidateMaskShouldReturnTrue(string mask)
        {
            //Act
            bool validMask = BoletoUtil.ValidateMask(mask);

            Assert.IsFalse(validMask);
        }


    }

}