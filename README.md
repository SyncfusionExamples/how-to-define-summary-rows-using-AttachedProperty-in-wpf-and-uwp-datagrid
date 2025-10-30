# How to Define Summary Rows using AttachedProperty in WPF / UWP DataGrid?

This example illustrates how to define summary rows using [AttachedProperty](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/properties/attached-properties-overview) in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) and [UWP DataGrid](https://www.syncfusion.com/uwp-ui-controls/datagrid) (SfDataGrid).

DataGrid provides support to show the column summary. If the DataContext of DataGrid is ViewModel, you can bind [SummaryColumns](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridSummaryRow.html#Syncfusion_UI_Xaml_Grid_GridSummaryRow_SummaryColumns) to a property in ViewModel using the AttachedProperty of type List &lt;GridSummaryColumn&gt;.

Refer to the following code example to define the AttachedProperty of type List &lt;GridSummaryColumn&gt;.

#### C#

``` csharp
public class SfDataGridAttachedProperty
{
    public static readonly DependencyProperty DynamicSummaryColumnsProperty = DependencyProperty.RegisterAttached("DynamicSummaryColumns",
        typeof(List<GridSummaryColumn>),
        typeof(SfDataGridAttachedProperty)
        , new FrameworkPropertyMetadata(null, OnDynamicSummaryColumnsChanged));

    public static void SetDynamicSummaryColumns(UIElement element, List<GridSummaryColumn> value)
    {
        element.SetValue(DynamicSummaryColumnsProperty, value);
    }
    public static List<GridSummaryColumn> GetDynamicSummaryColumns(UIElement element)
    {
        return (List<GridSummaryColumn>)element.GetValue(DynamicSummaryColumnsProperty);
    }

    private static void OnDynamicSummaryColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
    {
        SfDataGrid grid = d as SfDataGrid;

        if (grid.TableSummaryRows.Count() > 1)
        {
            grid.TableSummaryRows.Clear();
        }

        GridTableSummaryRow gsr = new GridTableSummaryRow();
        gsr.ShowSummaryInRow = false;

        var list = ((List<GridSummaryColumn>)args.NewValue);

        foreach (var item in list)
        {
            gsr.SummaryColumns.Add(item);
        }

        grid.TableSummaryRows.Add(gsr);
    }
}
```

Refer to the following code example to populate GridSummaryColumn in Viewmodel.

#### C#

``` csharp
internal class ViewModel : INotifyPropertyChanged
{
    private List<GridSummaryColumn> _summarycols;

    public List<GridSummaryColumn> SummaryColumns
    {
        get { return _summarycols; }
        set
        {
            _summarycols = value;
            RaisePropertyChanged("SummaryColumns");
        }
    }

    public ViewModel()
    {
        PopulateEmployeeDetails();
        SetSummaryColumns();
    }

    private void SetSummaryColumns()
    {
        SummaryColumns = new List<GridSummaryColumn>();
        SummaryColumns.Add(new GridSummaryColumn()
        {
            MappingName = "EmployeeID",
            Name = "EmployeeID",
            SummaryType = SummaryType.CountAggregate,
            Format = "Total: {Count}"
        });
        SummaryColumns.Add(new GridSummaryColumn()
        {
            MappingName = "EmployeeSalary",
            Name = "EmployeeSalary",
            SummaryType = SummaryType.DoubleAggregate,
            Format = "Total: {Sum}"
        });
    }
}
```

Refer to the following code example to bind the attached property in DataGrid.

#### XAML

``` xml
<Syncfusion:SfDataGrid x:Name="sfdatagrid"
                       local:SfDataGridAttachedProperty.DynamicSummaryColumns="{Binding SummaryColumns}"
                       ItemsSource="{Binding EmployeeDetails}">
</Syncfusion:SfDataGrid>
```