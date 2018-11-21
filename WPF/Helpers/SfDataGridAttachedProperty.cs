using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SfDataGridDemo
{
    public class SfDataGridAttachedProperty
    {
        public static readonly DependencyProperty DynamicSummaryColumnsProperty = DependencyProperty.RegisterAttached(
           "DynamicSummaryColumns",
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
}
