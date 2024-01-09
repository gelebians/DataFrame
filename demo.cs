using ISRA.Data;
using ISRA.System;
Console.WriteLine("DataFrame demo test:");
DataFrame dataframe = new DataFrame();
dataframe["T"] = new DataFrameData(new DateTime?[] { DateTime.Parse("01/01/2024"), DateTime.Parse("02/01/2024"), DateTime.Parse("03/01/2024"), DateTime.Parse("04/01/2024"), DateTime.Parse("05/01/2024") });
dataframe["close"] = new DataFrameData(new decimal?[] { 1.35m, 1.45m, 1.39m, 1.42m, 1.57m });
dataframe["high"] = new DataFrameData(new decimal?[] { 1.41m, 1.54m, 1.43m, 1.49m, 1.67m });
dataframe["low"] = new DataFrameData(new decimal?[] { 1.27m, 1.44m, 1.11m, 1.38m, 1.51m });

dataframe["hl2"] = (dataframe["high"] + dataframe["low"]) / 2; //hl2 calculation

//buy sell indicator
dataframe["buy"] = General.Where( dataframe["close"] < dataframe["low"].ShiftLeft(),"Buy","");
dataframe["sell"] = General.Where(dataframe["close"] > dataframe["high"].ShiftLeft(), "Sell", "");
dataframe["buysell"] = dataframe["buy"].Join(dataframe["sell"], "");

//sma calculation
dataframe["sma"] = dataframe["close"].Rolling(2).Mean();
Console.WriteLine(dataframe.ToString());

var a =Console.ReadLine();
