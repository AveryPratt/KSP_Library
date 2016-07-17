using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace KSP_Library
{
    namespace Rocketry
    {
        public class Rocket
        {
            // properties
            public string RocketName { get; set; }
            public int ID { get; set; }
            public List<Stage> StageList { get; set; }
            public double PayloadMass { get; set; }

            // constructors
            public Rocket()
            {
                StageList = new List<Stage>();
            }
            public Rocket(string rocketName)
            {
                RocketName = rocketName;
                StageList = new List<Stage>();
            }
            public Rocket(int id)
            {
                ID = id;
                StageList = new List<Stage>();
            }
            public Rocket(string rocketName, int id)
            {
                RocketName = rocketName;
                ID = id;
                StageList = new List<Stage>();
            }
            public Rocket(List<Stage> stageList)
            {
                StageList = stageList;
            }
            public Rocket(string rocketName, List<Stage> stageList)
            {
                RocketName = rocketName;
                StageList = stageList;
            }
            public Rocket(int id, List<Stage> stageList)
            {
                ID = id;
                StageList = stageList;
            }
            public Rocket(string rocketName, int id, List<Stage> stageList)
            {
                RocketName = rocketName;
                ID = id;
                StageList = stageList;
            }
            public Rocket(double payloadMass)
            {
                StageList = new List<Stage>();
                PayloadMass = payloadMass;
            }
            public Rocket(string rocketName, double payloadMass)
            {
                RocketName = rocketName;
                StageList = new List<Stage>();
                PayloadMass = payloadMass;
            }
            public Rocket(int id, double payloadMass)
            {
                ID = id;
                StageList = new List<Stage>();
                PayloadMass = payloadMass;
            }
            public Rocket(string rocketName, int id, double payloadMass)
            {
                RocketName = rocketName;
                ID = id;
                StageList = new List<Stage>();
                PayloadMass = payloadMass;
            }
            public Rocket(List<Stage> stageList, double payloadMass)
            {
                StageList = stageList;
                PayloadMass = payloadMass;
            }
            public Rocket(string rocketName, List<Stage> stageList, double payloadMass)
            {
                RocketName = rocketName;
                StageList = stageList;
                PayloadMass = payloadMass;
            }
            public Rocket(int id, List<Stage> stageList, double payloadMass)
            {
                ID = id;
                StageList = stageList;
                PayloadMass = payloadMass;
            }
            public Rocket(string rocketName, int id, List<Stage> stageList, double payloadMass)
            {
                RocketName = rocketName;
                ID = id;
                StageList = stageList;
                PayloadMass = payloadMass;
            }

            // methods
            public void AddPayloadMassToStages()
            {
                foreach (Stage stage in StageList)
                {
                    stage.WetMass += PayloadMass;
                    stage.DryMass += PayloadMass;
                }
            }
            public void SubtractPayloadMassFromStages()
            {
                foreach (Stage stage in StageList)
                {
                    stage.WetMass -= PayloadMass;
                    stage.DryMass -= PayloadMass;
                }
            }

            // calculations
            public int HighestWetMass(out object value)
            {
                return calculateHighest(InputValue.WetMass, out value);
            }
            public int LowestWetMass(out object value)
            {
                return calculateLowest(InputValue.WetMass, out value);
            }
            public double AverageWetMass()
            {
                return calculateAverage(InputValue.WetMass);
            }

            public int HighestDryMass(out object value)
            {
                return calculateHighest(InputValue.DryMass, out value);
            }
            public int LowestDryMass(out object value)
            {
                return calculateLowest(InputValue.DryMass, out value);
            }
            public double AverageDryMass()
            {
                return calculateAverage(InputValue.DryMass);
            }

            public double HighestMassRatio()
            {
                return calculateRatio(InputValue.WetMass, InputValue.DryMass).Max();
            }
            public double LowestMassRatio()
            {
                return calculateRatio(InputValue.WetMass, InputValue.DryMass).Min();
            }

            public int TotalDeltaV()
            {
                return (int)calculateTotal(InputValue.DeltaV);
            }
            public int HighestDeltaV(out object value)
            {
                return calculateHighest(InputValue.DeltaV, out value);
            }
            public int LowestDeltaV(out object value)
            {
                return calculateLowest(InputValue.DeltaV, out value);
            }
            public int AverageDeltaV()
            {
                return (int)calculateAverage(InputValue.DeltaV);
            }

            public int HighestIsp(out object value)
            {
                return calculateHighest(InputValue.Isp, out value);
            }
            public int LowestIsp(out object value)
            {
                return calculateLowest(InputValue.Isp, out value);
            }
            public int AverageIsp()
            {
                return (int)calculateAverage(InputValue.Isp);
            }

            public int HighestThrust(out object value)
            {
                return calculateHighest(InputValue.Thrust, out value);
            }
            public int LowestThrust(out object value)
            {
                return calculateLowest(InputValue.Thrust, out value);
            }
            public double AverageThrust()
            {
                return calculateAverage(InputValue.Thrust);
            }

            public int HighestMinTWR(out object value)
            {
                return calculateHighest(InputValue.MinTWR, out value);
            }
            public int LowestMinTWR(out object value)
            {
                return calculateLowest(InputValue.MinTWR, out value);
            }
            public double AverageMinTWR()
            {
                return calculateAverage(InputValue.MinTWR);
            }

            public int HighestMaxTWR(out object value)
            {
                return calculateHighest(InputValue.MaxTWR, out value);
            }
            public int LowestMaxTWR(out object value)
            {
                return calculateLowest(InputValue.MaxTWR, out value);
            }
            public double AverageMaxTWR()
            {
                return calculateAverage(InputValue.MaxTWR);
            }

            private double[] indexStagePropertyValues(InputValue stageProperty)
            {
                double[] values = new double[StageList.Count];
                foreach (Stage stage in StageList)
                {
                    switch (stageProperty)
                    {
                        case InputValue.WetMass:
                            values[stage.ID] = stage.WetMass - values.Sum(); // subtracting the sum of the object values before it means that each stage's wet mass will be individual and not cumulative.
                            break;
                        case InputValue.DryMass:
                            values[stage.ID] = stage.DryMass - values.Sum(); // subtracting the sum of the object values before it means that each stage's wet mass will be individual and not cumulative.
                            break;
                        case InputValue.Isp:
                            values[stage.ID] = stage.Isp;
                            break;
                        case InputValue.DeltaV:
                            values[stage.ID] = stage.DeltaV;
                            break;
                        case InputValue.Thrust:
                            values[stage.ID] = stage.Thrust;
                            break;
                        case InputValue.MinTWR:
                            values[stage.ID] = stage.MinTWR;
                            break;
                        case InputValue.MaxTWR:
                            values[stage.ID] = stage.MaxTWR;
                            break;
                        default:
                            break;
                    }
                }
                return values;
            }

            private double calculateTotal(InputValue stageProperty)
            {
                double[] values = indexStagePropertyValues(stageProperty);
                return values.Sum();
            }
            private double calculateAverage(InputValue stageProperty)
            {
                double[] values = indexStagePropertyValues(stageProperty);
                return values.Average();
            }
            private int calculateHighest(InputValue stageProperty, out object value)
            {
                double[] values = indexStagePropertyValues(stageProperty);
                value = values.Max();
                return Array.IndexOf(values, value) + 1;
            }
            private int calculateLowest(InputValue stageProperty, out object value)
            {
                double[] values = indexStagePropertyValues(stageProperty);
                value = values.Min();
                return Array.IndexOf(values, value) + 1;
            }
            private double[] calculateRatio(InputValue numerator, InputValue denominator)
            {
                double[] numeratorValues = indexStagePropertyValues(numerator);
                double[] denominatorValues = indexStagePropertyValues(denominator);
                double[] ratio = new double[StageList.Count()];
                for (int i = 0; i < StageList.Count(); i++)
                {
                    ratio[i] = numeratorValues[i] / denominatorValues[i];
                }
                return ratio;
            }

            // overrides
            public override string ToString()
            {
                string deltaV;
                try
                {
                    deltaV = TotalDeltaV().ToString();
                }
                catch
                {
                    deltaV = "NA";
                }
                StringBuilder rocketString = new StringBuilder(
                    "------------ Rocket ------------\n\n" +
                    RocketName +
                    ":\nID = " + ID +
                    "\nNo. of Stages = " + StageList.Count.ToString() +
                    "\nTotal Δv = " + deltaV +
                    "\n\n------------ Stages ------------\n\n");
                foreach (Stage stage in StageList)
                {
                    rocketString.Append(stage.ToString() + "\n\n");
                }
                rocketString.Append("--------------------------------");
                return rocketString.ToString();
            }
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                else if (!(obj is Rocket))
                {
                    return false;
                }
                else if (ID != ((Rocket)obj).ID)
                {
                    return false;
                }
                else return true;
            }
            public override int GetHashCode()
            {
                return ID.GetHashCode();
            }
        }

        public class Stage
        {
            // properties
            public string StageName { get; set; }
            public int ID { get; set; }
            public double WetMass { get; set; }
            public double DryMass { get; set; }
            public int Isp { get; set; }
            public int DeltaV { get; set; }
            public double Thrust { get; set; }
            public double MinTWR { get; set; }
            public double MaxTWR { get; set; }

            // constructors
            public Stage() { }
            public Stage(string stageName)
            {
                StageName = stageName;
            }
            public Stage(int id)
            {
                ID = id;
            }
            public Stage(string stageName, int id)
            {
                StageName = stageName;
                ID = id;
            }

            // calculations
            public void CalculateDeltaV()
            {
                DeltaV = (int)Math.Round(Math.Log(WetMass / DryMass) * 9.81 * Isp);
            }
            public void CalculateIsp()
            {
                Isp = (int)Math.Round(DeltaV / (Math.Log(WetMass / DryMass) * 9.81));
            }
            public void CalculateMinTWR()
            {
                MinTWR = Thrust / (WetMass * (9.81));
            }
            public void CalculateMaxTWR()
            {
                MaxTWR = Thrust / (DryMass * (9.81));
            }
            public void CalculateMinTWR(long GM, double Radius)
            {
                MinTWR = Thrust / (WetMass * (GM / Math.Pow(Radius, 2)));
            }
            public void CalculateMaxTWR(long GM, double Radius)
            {
                MaxTWR = Thrust / (DryMass * (GM / Math.Pow(Radius, 2)));
            }
            public void CalculateThrustFromMinTWR()
            {
                Thrust = MinTWR * (WetMass * (9.81));
            }
            public void CalculateThrustFromMaxTWR()
            {
                Thrust = MaxTWR * (DryMass * (9.81));
            }
            public void CalculateThrustFromMinTWR(long GM, double Radius)
            {
                Thrust = MinTWR * (WetMass * (GM / Math.Pow(Radius, 2)));
            }
            public void CalculateThrustFromMaxTWR(long GM, double Radius)
            {
                Thrust = MaxTWR * (DryMass * (GM / Math.Pow(Radius, 2)));
            }
            public void CalculateTWR()
            {
                CalculateMinTWR();
                CalculateMaxTWR();
            }
            public void CalculateTWR(long GM, double Radius)
            {
                CalculateMinTWR(GM, Radius);
                CalculateMaxTWR(GM, Radius);
            }

            #region Method Graveyard
            [Obsolete("Use CalculateDeltaV instead", true)]
            public int GetDeltaV()
            {
                DeltaV = (int)Math.Round(Math.Log(WetMass / DryMass) * 9.81 * Isp);
                return DeltaV;
            }
            [Obsolete("Use CalculateIsp instead", true)]
            public int GetIsp()
            {
                Isp = (int)Math.Round(DeltaV / (Math.Log(WetMass / DryMass) * 9.81));
                return Isp;
            }
            [Obsolete("Use CalculateMinTWR instead", true)]
            public double GetMinTWR()
            {
                MinTWR = Thrust / (WetMass * (9.81));
                return MinTWR;
            }
            [Obsolete("Use CalculateMaxTWR instead", true)]
            public double GetMaxTWR()
            {
                MaxTWR = Thrust / (DryMass * (9.81));
                return MaxTWR;
            }
            [Obsolete("Use CalculateMinTWR instead", true)]
            public double GetMinTWR(long GM, double Radius)
            {
                MinTWR = Thrust / (WetMass * (GM / Math.Pow(Radius, 2)));
                return MinTWR;
            }
            [Obsolete("Use CalculateMaxTWR instead", true)]
            public double GetMaxTWR(long GM, double Radius)
            {
                MaxTWR = Thrust / (DryMass * (GM / Math.Pow(Radius, 2)));
                return MaxTWR;
            }
            [Obsolete("Use CalculateThrustFromMinTWR instead", true)]
            public double GetThrustFromMinTWR()
            {
                Thrust = MinTWR * (WetMass * (9.81));
                return Thrust;
            }
            [Obsolete("Use CalculateThrustFromMaxTWR instead", true)]
            public double GetThrustFromMaxTWR()
            {
                Thrust = MaxTWR * (DryMass * (9.81));
                return Thrust;
            }
            [Obsolete("Use CalculateThrustFromMinTWR instead", true)]
            public double GetThrustFromMinTWR(long GM, double Radius)
            {
                Thrust = MinTWR * (WetMass * (GM / Math.Pow(Radius, 2)));
                return Thrust;
            }
            [Obsolete("Use CalculateThrustFromMaxTWR instead", true)]
            public double GetThrustFromMaxTWR(long GM, double Radius)
            {
                Thrust = MaxTWR * (DryMass * (GM / Math.Pow(Radius, 2)));
                return Thrust;
            }
            [Obsolete("Use CalculateTWR instead", true)]
            public void GetTWR(out double minTWR, out double maxTWR)
            {
                minTWR = GetMinTWR();
                maxTWR = GetMaxTWR();
            }
            [Obsolete("Use CalculateTWR instead", true)]
            public void GetTWR(long GM, double Radius, out double minTWR, out double maxTWR)
            {
                minTWR = GetMinTWR(GM, Radius);
                maxTWR = GetMaxTWR(GM, Radius);
            }
            #endregion

            // overrides
            public override string ToString()
            {
                string stageString = StageName +
                    ":\nID = " + ID +
                    ",\nWet Mass = " + WetMass +
                    ",\nDry Mass = " + DryMass +
                    ",\nIsp = " + Isp + 
                    ",\nΔv = " + DeltaV +
                    ",\nThrust = " + Thrust +
                    ",\nMin. TWR = " + MinTWR + 
                    ",\nMax. TWR = " + MaxTWR;
                return stageString.ToString();
        }
            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                else if (!(obj is Stage))
                {
                    return false;
                }
                else if (ID != ((Stage)obj).ID)
                {
                    return false;
                }
                else return true;
            }
            public override int GetHashCode()
            {
                return ID.GetHashCode();
            }
        }
    }
}
