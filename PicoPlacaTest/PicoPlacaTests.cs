using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PicoPlacaTest
{
    /// <summary>
    /// Unit Tests with right values, and errors in Plate Number, Date, and Time.
    /// </summary>
    [TestClass]
    public class PicoPlacaTests
    {
        /// <summary>
        /// Test functionality with right values.
        /// </summary>
        [TestMethod]
        public void TestPicoPlaca_With_Right_Values()
        {
            //Test variables
            string plateNumber = "PBN2476";
            string validateDate = "31/01/18";           //Format: dd/mm/yy
            string validateTime = "08:30";              //Format: hh:mm
            
            PicoPlaca.PicoPlaca test = new PicoPlaca.PicoPlaca();

            string result = test.CheckPicoPlaca(plateNumber, validateDate, validateTime);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Test error response with wrong plate Number.
        /// </summary>
        [TestMethod]
        public void TestPicoPlaca_With_Wrong_PlateNumber()
        {
            //Test variables
            string plateNumber = "PBN247G";             //Also verifies plate number length
            string validateDate = "31/01/18";           //Format: dd/mm/yy
            string validateTime = "08:30";              //Format: hh:mm

            PicoPlaca.PicoPlaca test = new PicoPlaca.PicoPlaca();

            string result = test.CheckPicoPlaca(plateNumber, validateDate, validateTime);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Test error response with wrong date format.
        /// </summary>
        [TestMethod]
        public void TestPicoPlaca_With_Wrong_Date()
        {
            //Test variables
            string plateNumber = "PBN2476";
            string validateDate = "31/31/18";           //Format: dd/mm/yy
            string validateTime = "08:30";              //Format: hh:mm

            PicoPlaca.PicoPlaca test = new PicoPlaca.PicoPlaca();

            string result = test.CheckPicoPlaca(plateNumber, validateDate, validateTime);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Test error response with wrong time format.
        /// </summary>
        [TestMethod]
        public void TestPicoPlaca_With_Wrong_Time()
        {
            //Test variables
            string plateNumber = "PBN2476";
            string validateDate = "31/01/18";           //Format: dd/mm/yy
            string validateTime = "25:30";              //Format: hh:mm

            PicoPlaca.PicoPlaca test = new PicoPlaca.PicoPlaca();

            string result = test.CheckPicoPlaca(plateNumber, validateDate, validateTime);

            Console.WriteLine(result);
        }
    }
}
