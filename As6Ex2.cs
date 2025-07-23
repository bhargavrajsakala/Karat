public class DataManager
{
    private List<string> _data;
 
    public List<string> Data
    {
        get
        {
            if (_data == null) 
            {
                _data = LoadData();  
            }
            return _data;
        }
    }
 
    private List<string> LoadData()
    {
        return new List<string> { "Alpha", "Beta", "Gamma" };
    }
}
//test method
[TestMethod]
public void Data_ShouldBeLoadedLazily()
{
    var manager = new DataManager();
    // Should be null before accessing the property
    Assert.IsNull(GetPrivateField(manager, "_data"));
    var data = manager.Data;
    // Should be initialized after property access
    Assert.IsNotNull(data);
}