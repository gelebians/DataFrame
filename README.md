# DataFrame
It is the implementation of Python dataframe on C#.
<br>In this project, SciSharp's pandas.net project was used. see https://github.com/SciSharp/Pandas.NET</br>
<h2>Usage Methods</h2>
<b>Creation</b>
<br>Create without parameters</br>
<br><code>DataFrame dataframe = new DataFrame();</code></br>
<br>Create by giving column name.</br>
<br><code>DataFrame dataframe = new DataFrame(new string[]{"col1","col2","col3");</code></br>
<br>Creating dataframedata array and column names as parameters. The column names parameter can be left blank. In this case, alphabetical letters are determined as the column name. Ex: "A","B","C".
Naming is done according to the number of dataframedata.If column names are given, data is retrieved as many as the number of columns. Even if the number of columns is more than the number of data, as many columns as the number of data are created.</br>
<br><code>List&lt;DataFrameData> list = new List&lt;DataFrameData>(5);
string[] colls1 = new string[7];
string[] colls2 = new string[4];
DataFrame dataframe1 = new DataFrame(list,colls1);
DataFrame dataframe2 = new DataFrame(list,colls2);
</code></br>
<br>Creating dataframe with single dataframedata.The column name parameter can be left blank. In this case, the column name is determined as the letter a</br>
<br><code>DataFrame = new DataFrame(new DataFrameData,"col1");</code></br>
<br>Creating Dataframe with dictinoary data type.The column names parameter can be left blank.<br>
<br><code>Dictionary&lt;string,IConvertible[]> list = new DDictionary&lt;string,IConvertible[]>(5);
string[] colls1 = new string[7];
string[] colls2 = new string[4];
DataFrame dataframe1 = new DataFrame(list,colls1);
DataFrame dataframe2 = new DataFrame(list,colls2);
</code></br>
<br>Creating Dataframe with custom object type. Column names will be the names of the object elements.<br>
<br><code>public class CustomClass{
    public int Int1 { get; set; }
    public string String1 { get; set; }
    public decimal Decimal1 { get; set; }
    public DateTime DateTime1 { get; set; }
}
List&lt;CustomClass> customlist = new List&lt;CustomClass>(4);
DataFrame dataframe1 = new DataFrame(customlist);
</code></br>
<h2>DataFrame Items</h2>
<br><b>Columns: </b> Returns columns in dictionary format</br>
<br><b>Count: </b> Returns the number of rows of any column. The row numbers of all columns must be equal.</br>
<h2>Methods</h2>
<br><b>AddRow: </b> Adds new line. The added row must contain all columns.</br>
<br><code>IConvertible[] row = new IConvertible[] { DateTime.Now, 5, "row3", 6.0m, 5.13d };
List&lt;IConvertible> row2 = new List&lt;IConvertible>(){DateTime.Now, 5, "row3", 6.0m, 5.13};
dataframe.AddRow(row);
dataframe.AddRow(3,row2); // by giving line number
</code></br>
<br><b>DeleteRow: </b> deletes the line given the line number</br>
<br><code>dataframe.DeleteRow(1);</code></br>
<br><b>Clear: </b> clears all lines</br>
<br><code>dataframe.Clear();</code></br>
<br><b>Rename: </b> Replaces the column name with the new name. It must be in Dictionary&lt;string,string> format.</br>
<br><code>dataframe.Rename(new Dictionary&lt;string,string>(){{"col1","newcol1"},{"col2","newcoll2"}};</code></br>
<br><b>Short: </b> Reorder all rows with given column name.</br>
<br><code>dataframe.Short("T",ShortSide.Desc);</code></br>
<h2>Indexing</h2>
<br><b>DataFrameData this[string collname]: </b> Returns the column called column as Dataframedata.</br>
<br><code>var dataframe2 = dataframe1["coll1"];</code></br>
<br><b>DataFrameData this[string collname, int rowstart, int rowend]: </b> Returns the column called column as Dataframedata within the specified range.</br>
<br><code>var dataframe2 = dataframe1["coll1", 1, 5];</code></br>
<br><b>IConvertible? this[string collname, int row]: </b> Returns the data in the specified row and column.</br>
<br><code>var data = dataframe1["coll1", 1];</code></br>
<br><b>List&lt;IConvertible?> this[int row]: </b> Returns the data in the form of a list in the given row.</br>
<br><code>var datas = dataframe1[1];</code></br>
<br><b>DataFrame this[string[] colls]: </b> Returns the columns given as parameters as DataFrame.</br>
<br><code>var dataframe2 = dataframe1[new string[]{"col1","col2"}];</code></br>
<br>Columns can be added later using the indexing method.The column to be added must have data. The size of the DataFrameData to be added must be the same as the DataFrame. If the DataFrame is empty, the size will be the DataFrameData size. ex:</br>
<br><code>var dataframe = new DataFrame();
dataframe["col1"]=new DataFrameData(typeof(int),10);</code></br>
In this example, a new column named col1 has been added.
<br>The value of the data can be changed with the indexing method. ex:</br>
<br><code>dataframe["col1",3] = 12;</code></br>
<h1>DataFrameData</h1>
<br>This is the most comprehensive object. Mathematical operations, comparison, averaging and square root operations can be performed with DataFrameData. All data types used must be of nullable type. Example: new DataFrameData(new int?[5])</br>
<h2>Usage Methods</h2>
<b>Creation</b>
<br>Create by specifying type and size</br>
<br><code>DataFrameData dataframedata = new DataFrame(typeof(int),10);</code></br>
<br>Create with array</br>
<br><code>float[] array = new float[]{3.5, 2.75, 1.43, 14.6};
DataFrameData dataframedata = new DataFrame(array);</code></br>
<h2>DataFrameData Items</h2>
<br><b>Values: </b> Array of values</br>
<br><b>Type: </b> DataFrameData type of data of the data.</br>
<h2>Methods</h2>
<br><b>Add: </b> Add new data</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(int),3);
dataframedata.Add(5);
dataframedata.Add(0,5); //Adding data with index number
</code></br>
<br><b>Delete: </b> Deletes the data given the index number</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(int),3);
dataframedata.Delete(1);</code></br>
<br><b>Clear: </b> Clears all data</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(int),3);
dataframedata.Celar();</code></br>
<br><b>ToString: </b> Converts data to string in tabular form</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(int),3);
Console.WriteLine(dataframedata.ToString());</code></br>
<br><b>ShiftLeft: </b> Shifts the array to the left by the given number. Initial values ​​are assigned as null</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(int),10);
dataframedata2 = dataframedata.ShiftLeft(1);</code></br>
<br><b>ShiftRight: </b> Shifts the array to the right by the given number. Initial values ​​are assigned as null</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(int),10);
dataframedata2 = dataframedata.ShiftRight(2);</code></br>
<br><b>index: </b> Returns the index number of the given data</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(decimal),5);
int index = dataframedata.index(10m);</code></br>
<br><b>ForEach: </b> Foreach method used in the list method</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(decimal),7);
dataframedata.ForEach(Console.WriteLine);</code></br>
<br><b>Rolling: </b> Implementation of pandas.rolling function. For explanation: <a href="https://www.geeksforgeeks.org/python-pandas-dataframe-rolling/">here</a></br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(decimal),128);
List&lt;DataFrameData> datalist = dataframedata.Rolling(5);</code></br>
<br><b>First: </b> Returns the first data</br>
<br><code>IConvertible? data = dataframedata.First();</code></br>
<br><b>Last: </b> Returns the last data</br>
<br><code>IConvertible? data = dataframedata.Last();</code></br>
<br><b>Count: </b> Returns the total number of data</br>
<br><code>int size = dataframedata.Count();</code></br>
<br><b>Sum: </b> Returns the total of the datas</br>
<br><code>IConvertible sum = dataframedata.Sum();</code></br>
<br><b>Mean: </b> Averages the datas</br>
<br><code>IConvertible mean = dataframedata.Mean();</code></br>
<br><b>Min: </b> Returns the minimum of all data</br>
<br><code>IConvertible min = dataframedata.Min();</code></br>
<br><b>Max: </b> Returns the maximum of all data</br>
<br><code>IConvertible max = dataframedata.Max();</code></br>
<br><b>Abs: </b> Returns the absolute value of a number</br>
<br><code>DataFrameData abs = dataframedata.Abs();</code></br>
<br><b>Diff: </b> Find the difference between the values for each row and the values from the previous row</br>
<br><code>DataFrameData diff = dataframedata.Diff();</code></br>
<br><b>Clip: </b> Used to trim values at specified input threshold. We can use this function to put a lower limit and upper limit on the values that any cell can have in the dataframe.</br>
<br><code>DataFrameData clip = dataframedata.Clip();</code></br>
<br><b>Std: </b> Return sample standard deviation over requested axis.</br>
<br><code>DataFrameData std = dataframedata.Std();</code></br>
<br><b>Join: </b> merge existing DataFrameData with DataFrameData given in parameter</br>
<br><code>DataFrameData joins = dataframedata.Join(dataframedata2,"both");</code></br>
<br><b>Ewm: </b> ewm method used in pandas.dataframe</br>
<br><code>DataFrameData ewm = dataframedata.Ewm(21);</code></br>
<br><b>Sma: </b> sma indicator</br>
<br><code>DataFrameData sma = dataframedata.Sma(50);</code></br>
<br><b>Ema: </b> ema indicator</br>
<br><code>DataFrameData ema = dataframedata.Ema(17);</code></br>
<br><b>Wma: </b> wma indicator</br>
<br><code>DataFrameData wma = dataframedata.Wma(18);</code></br>
<br><b>Hma: </b> hma indicator</br>
<br><code>DataFrameData hma = dataframedata.Hma(18);</code></br>
<br><b>StockRsi: </b> stochastic rsi indicator</br>
<br><code>DataFrameData stock = dataframedata.StockRsi(14,3);</code></br>
<h2>Indexing</h2>
<br>Returns the data given the index number</br>
<br><code>IConvertible data = dataframedata[1];</code></br>
<br>Index number returns data up to the size of the given number.</br>
<br><code>DataFrameData dataframedata2 = dataframedata[1,3]; //The size of the new DataFrameData is 3</code></br>
<h2>Operators</h2>
<b>Contain Operators</b>
<br><b>==, != , >, <, >=, <=, & Operators:</b></br>
<br><code>DataFrameData newDataFrameData = dataframedata1 == dataframedata2; //The values ​​of the new dataframedata will be of type bool
DataFrameData newDataFrameData = dataframedata1 != dataframedata2;
DataFrameData newDataFrameData = dataframedata1 > dataframedata2;
DataFrameData newDataFrameData = dataframedata1 & dataframedata2; //Do not use it with two & characters. It will be single & character
    ....
</code></br>
<b>Math Operators</b>
<br><b>+, -, *, /, ++, --, % Operators:</b></br>
<br><code>DataFrameData newDataFrameData = dataframedata1 == dataframedata2; //The values ​​of the new dataframedata will be of type bool
DataFrameData newDataFrameData = dataframedata1 + dataframedata2;
DataFrameData newDataFrameData = dataframedata1 / dataframedata2;
DataFrameData newDataFrameData = dataframedata1 % dataframedata2;
DataFrameData newDataFrameData = dataframedata1++;
    ....
</code></br>
<h2>Examples</h2>
<br><code>DataFrame dataframe = new DataFrame();
dataframe["T"] = new DataFrameData(new DateTime?[5]{DateTime.Parse("01.01.2024","02.01.2024","03.01.2024","04.01.2024","05.01.2024"});
dataframe["high"] = new DataFrameData(new decimal?[5]{"5.12,6.25,5.13,8.26,15});
dataframe["low"] = new DataFrameData(new decimal?[5]{"4.48,5.15,3.27,7.55,11,45});
dataframe["close"] = new DataFrameData(new decimal?[5]{"4.51,5.18,3.51,7.99,13,74});
dataframe["hl2"] = (dataframe["high"]+dataframe["low"])/2;

//Calculate 10 days sma
dataframe["sma"] = dataframe["close"].Rolling(10).Mean();

//Buy Sell indicator
dataframe["buy"] = General.Where(dataframe["close"] < dataframe["low"].ShiftLeft(),"BUY",""); //Buy if the close is less than the previous low
dataframe["sell"] = General.Where(dataframe["close"] > dataframe["high"].ShiftLeft(),"SELL",""); //Sell ​​if the close is higher than the previous high
dataframe["buysell"] = dataframe["buy"].Join(dataframe["sell"],"");  //Combine buy and sell and put them in one column
</code></br>
