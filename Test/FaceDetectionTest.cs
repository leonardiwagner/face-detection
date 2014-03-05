using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using FaceDetection;

namespace Test
{
    [TestClass]
    public class FaceDetectionTest
    {
        private DetectionSensibility sensibility = DetectionSensibility.High;

        /*
        [TestMethod]
        public void Face()
        {
            FaceDetection.Detection faceDetection = new Detection();

            String[] files = System.IO.Directory.GetFiles("C:\\Temp");
            foreach(String file in files)
            {
                FaceDetection.DetectionReturn detectionReturn = faceDetection.DetectFace(DetectionType.Face, file, sensibility);

                faceDetection.SaveDetection(detectionReturn, "C:\\Temp\\Face\\" + Path.GetFileName(file));
            }
        }

        [TestMethod]
        public void Face2()
        {
            FaceDetection.Detection faceDetection = new Detection();

            String[] files = System.IO.Directory.GetFiles("C:\\Temp");
            foreach (String file in files)
            {
                FaceDetection.DetectionReturn detectionReturn = faceDetection.DetectFace(DetectionType.Face2, file, sensibility);

                faceDetection.SaveDetection(detectionReturn, "C:\\Temp\\Face2\\" + Path.GetFileName(file));
            }
        }

        [TestMethod]
        public void Face3()
        {
            FaceDetection.Detection faceDetection = new Detection();

            String[] files = System.IO.Directory.GetFiles("C:\\Temp");
            foreach (String file in files)
            {
                FaceDetection.DetectionReturn detectionReturn = faceDetection.DetectFace(DetectionType.Face3, file, sensibility);

                faceDetection.SaveDetection(detectionReturn, "C:\\Temp\\Face3\\" + Path.GetFileName(file));
            }
        }

        [TestMethod]
        public void Face4()
        {
            FaceDetection.Detection faceDetection = new Detection();

            String[] files = System.IO.Directory.GetFiles("C:\\Temp");
            foreach (String file in files)
            {
                FaceDetection.DetectionReturn detectionReturn = faceDetection.DetectFace(DetectionType.Face4, file, sensibility);

                faceDetection.SaveDetection(detectionReturn, "C:\\Temp\\Face4\\" + Path.GetFileName(file));
            }
        }
        */

        [TestMethod]
        public void Profile()
        {
            FaceDetection.Detection faceDetection = new Detection();

            String[] files = System.IO.Directory.GetFiles("C:\\Temp");
            foreach (String file in files)
            {
                FaceDetection.DetectionReturn detectionReturn = faceDetection.DetectFace(DetectionType.Profile, file, sensibility);

                faceDetection.SaveDetection(detectionReturn, "C:\\Temp\\Profile\\" + Path.GetFileName(file));
            }
        }
    }
}
