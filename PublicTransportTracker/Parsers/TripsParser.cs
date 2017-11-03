using PublicTransportTracker.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace PublicTransportTracker.Parsers
{
    //route_id      trip_id     service_id      trip_headsign       direction_id, shape_id

    //shapes serão tratados dentro desse mesmo parser

    //shapes:       shape_id        shape_pt_lat        shape_pt_lon        shape_pt_seq

    //gerar pontos através do arquivo shapes e inserir na entidade route

    public class TripsParser
    {
        private static List<int> tripIndexes = new List<int>();
        private static List<int> shapeIndexes = new List<int>();

        private static List<ShapeCoordinate> shapes = new List<ShapeCoordinate>();

        public static List<Trip> getTripList(HttpPostedFileBase tripFile, HttpPostedFileBase shapeFile)
        {
            int teste = 0;
            getShapeList(shapeFile);
            List<Trip> tripList = new List<Trip>();
            StreamReader tripStream = new StreamReader(tripFile.InputStream);
            getIndexesTrip(tripStream.ReadLine());
            string tripLine = tripStream.ReadLine();
            while (tripLine != null)
            {
                Trip trip = new Trip();
                List<string> tripValues = BaseParser.getValuesByLine(tripLine, tripIndexes);
                trip.routeID = tripValues[0];
                trip.tripID = tripValues[1];
                trip.serviceID = tripValues[2];
                if (tripIndexes[3] != -1) trip.tripHeadSign = tripValues[3];
                trip.directionID = Convert.ToInt32(tripValues[4]);
                string shapeID = tripValues[5];
                trip.coordinates = shapes.Where(s => s.shapeID == shapeID).ToList();// getCoordinateList(shapeFile, shapeID);                
                if (trip.coordinates.Count < 2)
                {
                    for(int i = 0; i < 3; i++)
                    {
                        trip.coordinates.Add(new ShapeCoordinate
                        {
                            latitude = "0.0",
                            longitude = "0.0",
                        });
                    }

                    teste++;
                }
                tripList.Add(trip);
                tripLine = tripStream.ReadLine();
                //Debug.WriteLine(trip.routeID);
            }
            return tripList;
        }

        public static void getShapeList(HttpPostedFileBase shapeFile)
        {
            StreamReader shapeStream = new StreamReader(shapeFile.InputStream);
            getIndexesShape(shapeStream.ReadLine());
            string shapeLine = shapeStream.ReadLine();           
            while (shapeLine != null)
            {
                ShapeCoordinate s = new ShapeCoordinate();
                List<string> shapeValues = BaseParser.getValuesByLine(shapeLine, shapeIndexes);
                s.shapeID = shapeValues[0];
                s.latitude = shapeValues[1];
                s.longitude = shapeValues[2];
                s.pointSeq = Convert.ToInt32(shapeValues[3]);
                shapes.Add(s);
                shapeLine = shapeStream.ReadLine();
            }

        }

        #region Helper Methods

        private static void getIndexesTrip(string header)
        {
            tripIndexes.Add(BaseParser.getFieldIndexByName(header, "route_id"));
            tripIndexes.Add(BaseParser.getFieldIndexByName(header, "trip_id"));
            tripIndexes.Add(BaseParser.getFieldIndexByName(header, "service_id"));
            tripIndexes.Add(BaseParser.getFieldIndexByName(header, "trip_headsign"));
            tripIndexes.Add(BaseParser.getFieldIndexByName(header, "direction_id"));
            tripIndexes.Add(BaseParser.getFieldIndexByName(header, "shape_id"));
        }

        private static void getIndexesShape(string header)
        {
            shapeIndexes.Add(BaseParser.getFieldIndexByName(header, "shape_id"));
            shapeIndexes.Add(BaseParser.getFieldIndexByName(header, "shape_pt_lat"));
            shapeIndexes.Add(BaseParser.getFieldIndexByName(header, "shape_pt_lon"));
            shapeIndexes.Add(BaseParser.getFieldIndexByName(header, "shape_pt_sequence"));
        }

        #endregion

    }
}