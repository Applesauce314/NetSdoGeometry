using Oracle.ManagedDataAccess.Types;

using System;
using System.Globalization;
using System.Text;

namespace NetSdoGeometry
{

    [Serializable]
    [OracleCustomTypeMapping("MDSYS.SDO_GEOMETRY")]
    public class SdoGeometry : OracleCustomTypeBase<SdoGeometry>
    {
        [OracleObjectMapping(0)]
        public decimal? SdoGtype { get; set; }

        [OracleObjectMapping(1)]
        public decimal? SdoSRID { get; set; }

        [OracleObjectMapping(2)]
        public SdoPoint? SdoPoint { get; set; }

        [OracleObjectMapping(3)]
        public decimal[]? SdoElemInfo { get; set; }

        [OracleObjectMapping(4)]
        public decimal[]? SdoOrdinates { get; set; }

        public int SdoGtypeAsInt => System.Convert.ToInt32(this.SdoGtype, CultureInfo.InvariantCulture);

        public int SdoSRIDAsInt
        {
            get => System.Convert.ToInt32(this.SdoSRID, CultureInfo.InvariantCulture);

            set => this.SdoSRID = System.Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        public int[]? ElemArrayOfInts
        {
            get
            {
                int[]? elems = null;
                if (this.SdoElemInfo != null)
                {
                    elems = new int[this.SdoElemInfo.Length];
                    for (var k = 0; k < this.SdoElemInfo.Length; k++)
                    {
                        elems[k] = System.Convert.ToInt32(this.SdoElemInfo[k], CultureInfo.InvariantCulture);
                    }
                }

                return elems;
            }

            set
            {
                if (value != null)
                {
                    var c = value.GetLength(0);
                    this.SdoElemInfo = new decimal[c];

                    for (var k = 0; k < c; k++)
                    {
                        this.SdoElemInfo[k] = System.Convert.ToDecimal(value[k], CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    this.SdoElemInfo = null;
                }
            }
        }

        public double[]? OrdinatesArrayOfDoubles
        {
            get
            {
                double[]? elems = null;
                if (this.SdoOrdinates != null)
                {
                    elems = new double[this.SdoOrdinates.Length];
                    for (int k = 0; k < this.SdoOrdinates.Length; k++)
                    {
                        elems[k] = System.Convert.ToDouble(this.SdoOrdinates[k], CultureInfo.InvariantCulture);
                    }
                }

                return elems;
            }

            set
            {
                if (value != null)
                {
                    var c = value.GetLength(0);
                    this.SdoOrdinates = new decimal[c];
                    for (int k = 0; k < c; k++)
                    {
                        this.SdoOrdinates[k] = System.Convert.ToDecimal(value[k], CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    this.SdoOrdinates = null;
                }
            }
        }

        public int Dimensionality { get; set; }

        public int LRS { get; set; }

        public int GeometryType { get; set; }

        public string AsText
        {
            get
            {
                StringBuilder sb = new();
                _ = sb.Append("MDSYS.SDO_GEOMETRY(");
                _ = sb.Append(this.SdoGtype?.ToString(CultureInfo.InvariantCulture) ?? "null");
                _ = sb.Append(',');
                _ = sb.Append(this.SdoSRID?.ToString(CultureInfo.InvariantCulture) ?? "null");
                _ = sb.Append(',');

                // begin point
                if (this.SdoPoint != null)
                {
                    _ = sb.Append("MDSYS.SDO_POINT_TYPE(");
                    _ = sb.Append(string.Format(CultureInfo.InvariantCulture,
                        "{0:#.##########},{1:#.##########}{2}{3:#.##########}",
                        this.SdoPoint.X,
                        this.SdoPoint.Y,
                        (this.SdoPoint.Z == null) ? null : ",",
                        this.SdoPoint.Z).Trim());
                    _ = sb.Append(')');
                }
                else
                {
                    _ = sb.Append("null");
                }

                _ = sb.Append(',');

                // begin element array
                if (this.SdoElemInfo != null)
                {
                    _ = sb.Append("MDSYS.SDO_ELEM_INFO_ARRAY(");
                    for (int i = 0; i < this.SdoElemInfo.Length; i++)
                    {
                        _ = sb.Append(string.Format(CultureInfo.InvariantCulture, "{0}", this.SdoElemInfo[i]));
                        if (i < (this.SdoElemInfo.Length - 1))
                        {
                            _ = sb.Append(',');
                        }
                    }

                    _ = sb.Append(')');
                }
                else
                {
                    _ = sb.Append("null");
                }

                _ = sb.Append(',');

                // begin ordinates array
                if (this.SdoOrdinates != null)
                {
                    _ = sb.Append("MDSYS.SDO_ORDINATE_ARRAY(");
                    for (var i = 0; i < this.SdoOrdinates.Length; i++)
                    {
                        _ = sb.Append(string.Format(CultureInfo.InvariantCulture, "{0:#.##########}", this.SdoOrdinates[i]));
                        if (i < (this.SdoOrdinates.Length - 1))
                        {
                            _ = sb.Append(',');
                        }
                    }

                    _ = sb.Append(')');
                }
                else
                {
                    _ = sb.Append("null");
                }

                _ = sb.Append(')');

                return sb.ToString();
            }
        }

        public override void MapFromCustomObject()
        {
            this.SetValue((int)OracleObjectColumns.SDO_GTYPE, this.SdoGtype);
            this.SetValue((int)OracleObjectColumns.SDO_SRID, this.SdoSRID);
            this.SetValue((int)OracleObjectColumns.SDO_POINT, this.SdoPoint);
            this.SetValue((int)OracleObjectColumns.SDO_ELEM_INFO, this.SdoElemInfo);
            this.SetValue((int)OracleObjectColumns.SDO_ORDINATES, this.SdoOrdinates);
        }

        public override void MapToCustomObject()
        {
            this.SdoGtype = this.GetValue<decimal?>((int)OracleObjectColumns.SDO_GTYPE);
            this.SdoSRID = this.GetValue<decimal?>((int)OracleObjectColumns.SDO_SRID);
            this.SdoPoint = this.GetValue<SdoPoint>((int)OracleObjectColumns.SDO_POINT);
            this.SdoElemInfo = this.GetValue<decimal[]>((int)OracleObjectColumns.SDO_ELEM_INFO);
            this.SdoOrdinates = this.GetValue<decimal[]>((int)OracleObjectColumns.SDO_ORDINATES);
        }

        public int PropertiesFromGTYPE()
        {
            if (this.SdoGtype is not null and not 0)
            {
                int v = (int)this.SdoGtype.Value;
                int dim = v / 1000;
                this.Dimensionality = dim;
                v -= dim * 1000;
                int lrsDim = v / 100;
                this.LRS = lrsDim;
                v -= lrsDim * 100;
                this.GeometryType = v;
                return (this.Dimensionality * 1000) + (this.LRS * 100) + this.GeometryType;
            }
            else
            {
                return 0;
            }
        }

        public int PropertiesToGTYPE()
        {
            var v = this.Dimensionality * 1000;
            v = v + (this.LRS * 100);
            v = v + this.GeometryType;

            this.SdoGtype = System.Convert.ToDecimal(v, CultureInfo.InvariantCulture);

            return v;
        }

        public override string ToString()
        {
            return this.AsText;
        }
    }
}