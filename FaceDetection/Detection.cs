using System;
using System.Collections.Generic;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

using System.Drawing;

namespace FaceDetection
{
    public enum DetectionType
    {
        Default,
        Profile,
        Face,
        Face2,
        Face3,
        Face4
    }

    public enum DetectionSensibility
    {
        Default = 10,
        Normal = 10,
        Lowest = 25,
        Low = 15,
        High = 5,
        Highest = 2
    }

    public class DetectionReturn
    {
        private readonly List<Rectangle> _detections;
        private readonly Image<Bgr, byte> _image;

        public DetectionReturn(Image<Bgr, byte> image, List<Rectangle> detections)
        {
            this._image = image;
            this._detections = detections;
        }

        public Image<Bgr, byte> Image
        {
            get
            {
                return this._image;
            }
        }

        public List<Rectangle> Detections
        {
            get
            {
                return this._detections;
            }
        }

        public bool HasDetected
        {
            get
            {
                return this._detections.Count > 0 ? true : false;
            }
        }
    }

    public class Detection
    {

        public DetectionReturn DetectFace(DetectionType detectionType, String fileName, DetectionSensibility detectionSensibility)
        {
            return this.DetectFace(detectionType, fileName, (int)detectionSensibility, 20);
        }

        public DetectionReturn DetectFace(DetectionType detectionType, String fileName, int sensibility, int minSize)
        {
         
            HaarCascade faceDetection;
            
            switch(detectionType)
            {
                case DetectionType.Profile:
                    faceDetection = new HaarCascade(@"C:\Users\wagner\Documents\visual studio 2013\Projects\FaceDetection\FaceDetection\haarcascade_profileface.xml");
                    break;
                case DetectionType.Face2:
                    faceDetection = new HaarCascade(@"C:\Users\wagner\Documents\visual studio 2013\Projects\FaceDetection\FaceDetection\haarcascade_frontalface_alt.xml");
                    break;
                case DetectionType.Face3:
                    faceDetection = new HaarCascade(@"C:\Users\wagner\Documents\visual studio 2013\Projects\FaceDetection\FaceDetection\haarcascade_frontalface_alt2.xml");
                    break;
                case DetectionType.Face4:
                    faceDetection = new HaarCascade(@"C:\Users\wagner\Documents\visual studio 2013\Projects\FaceDetection\FaceDetection\haarcascade_frontalface_alt_tree.xml");
                    break;
                case DetectionType.Default:
                    faceDetection = new HaarCascade(@"C:\Users\wagner\Documents\visual studio 2013\Projects\FaceDetection\FaceDetection\haarcascade_frontalface_default.xml");
                    break;
                case DetectionType.Face:
                    faceDetection = new HaarCascade(@"C:\Users\wagner\Documents\visual studio 2013\Projects\FaceDetection\FaceDetection\haarcascade_frontalface_default.xml");
                    break;
                default:
                    faceDetection = new HaarCascade(@"C:\Users\wagner\Documents\visual studio 2013\Projects\FaceDetection\FaceDetection\haarcascade_frontalface_default.xml");
                    break;
            }

            Image<Bgr, byte> image = new Image<Bgr, byte>(fileName);
            Image<Gray, byte> imageGray = image.Convert<Gray,byte>();

            MCvAvgComp[] detectedFaces = imageGray.DetectHaarCascade(faceDetection, 1.1, sensibility, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DEFAULT, new Size(minSize, minSize))[0];
            
            List<Rectangle> rectList = new List<Rectangle>();
            foreach (var face in detectedFaces)
            {
                rectList.Add(new Rectangle()
                {
                    X = face.rect.X,
                    Y = face.rect.Y,
                    Height = face.rect.Height,
                    Width = face.rect.Height,
                    Size = face.rect.Size,
                    Location = face.rect.Location
                });
            }

            return new DetectionReturn(image, rectList);
        }

        public void SaveDetection(DetectionReturn detectionReturn, String fileNameToSave)
        {
            foreach (Rectangle item in detectionReturn.Detections)
            {
                detectionReturn.Image.Draw(item, new Bgr(0, 0, 255), 2);
            }

            detectionReturn.Image.Save(fileNameToSave);
        }
    }
}
