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
<br>This is the most comprehensive object. Mathematical operations, comparison, averaging and square root operations can be performed with DataFrameData.</br>
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
<br><b>First: Returns the first data</br>
<br><code>DataFrameData dataframedata = new DataFrameData(typeof(decimal),128);
List&lt;DataFrameData> datalist = dataframedata.Rolling(5);</code></br>
