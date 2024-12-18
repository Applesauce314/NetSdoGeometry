﻿using System;

namespace NetSdoGeometry
{

    [Serializable]
    public static class SdoGeometryTypes
    {
        // Oracle Documentation for SDO_ETYPE - SIMPLE
        // Point//Line//Polygon//exterior counterclockwise - polygon ring = 1003//interior clockwise  polygon ring = 2003
        public enum ETYPE_SIMPLE
        {
            POINT = 1,
            LINE = 2,
            POLYGON = 3,
            POLYGON_EXTERIOR = 1003,
            POLYGON_INTERIOR = 2003
        }

        // Oracle Documentation for SDO_ETYPE - COMPOUND
        // 1005: exterior polygon ring (must be specified in counterclockwise order)
        // 2005: interior polygon ring (must be specified in clockwise order)
        public enum ETYPE_COMPOUND
        {
            FOURDIGIT = 4,
            POLYGON_EXTERIOR = 1005,
            POLYGON_INTERIOR = 2005
        }

        /// <summary>
        /// Oracle Documentation for SDO_GTYPE.
        /// This represents the last two digits in a GTYPE, where the first item is dimension(ality) and the second is LRS
        /// </summary>
        public enum GTYPE
        {
            UNKNOWN_GEOMETRY = 00,
            POINT = 01,
            LINE = 02,
            CURVE = LINE,
            POLYGON = 03,
            COLLECTION = 04,
            MULTIPOINT = 05,
            MULTILINE = 06,
            MULTICURVE = MULTILINE,
            MULTIPOLYGON = 07
        }

        public enum DIMENSION
        {
            DIM2D = 2,
            DIM3D = 3,
            LRS_DIM3 = DIM3D,
            LRS_DIM4 = 4
        }
    }
}
