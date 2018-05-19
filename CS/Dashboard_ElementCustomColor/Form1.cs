using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.DashboardWin;
using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;

namespace Dashboard_ElementCustomColor {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
            dashboardViewer1.LoadDashboard(@"..\..\Data\Dashboard.xml");
        }

        private void dashboardViewer1_DashboardItemElementCustomColor(object sender,             
            DashboardItemElementCustomColorEventArgs e) {

            MultiDimensionalData data = e.Data;
            AxisPointTuple currentElement = e.TargetElement;
            
            if (e.DashboardItemName == "chartDashboardItem1") {
                string country = 
                    currentElement.GetAxisPoint(DashboardDataAxisNames.ChartSeriesAxis).Value.ToString();
                decimal value = (decimal)(data.GetSlice(currentElement)).GetValue(e.Measures[0]).Value;
                if (country == "UK" && value > 50000 || country == "USA" && value > 100000)
                    e.Color = Color.DarkGreen;
                else 
                    e.Color = Color.DarkRed;
            }
            if (e.DashboardItemName == "pieDashboardItem1") {
                decimal value = 
                    (decimal)(data.GetSlice(currentElement)).GetValue(data.GetMeasures()[0]).Value;
                if (value < 100000)
                    e.Color = Color.Orange;
            }
        }
    }
}
