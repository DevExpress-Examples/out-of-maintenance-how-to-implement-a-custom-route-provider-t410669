using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomRouteProvider {
    public partial class Form1 : Form {
        InformationLayer Layer { get { return (InformationLayer)mapControl1.Layers[1]; } }
        public Form1() {
            InitializeComponent();
            RouteProvider provider = new RouteProvider();
            Layer.DataProvider = provider;
            provider.CalculateRoute(new GeoPoint(70, 60), new GeoPoint(-60, -70));
        }
    }
    public class RouteProvider : InformationDataProviderBase {
        protected new RouteData Data { get { return (RouteData)base.Data; } }
        public IEnumerable<GeoPoint> Route { get { return Data.Route; } }

        protected override IInformationData CreateData() {
            return new RouteData();
        }
        public void CalculateRoute(GeoPoint point1, GeoPoint point2) {
            Data.CalculateRoute(point1, point2);
        }
    }
    public class RouteData : IInformationData {
        readonly List<GeoPoint> route = new List<GeoPoint>();
        public List<GeoPoint> Route { get { return route; } }
        public event EventHandler<RequestCompletedEventArgs> OnDataResponse;
        RequestCompletedEventArgs CreateEventArgs() {
            MapItem[] items = new MapItem[3];
            items[1] = new MapCallout() { Location = route[0], Text = route[0].ToString() };
            items[2] = new MapCallout() { Location = route[route.Count - 1], Text = route[route.Count - 1].ToString() };
            MapPolyline polyline = new MapPolyline() { IsGeodesic = true, Stroke = System.Drawing.Color.Red, StrokeWidth = 4 };
            for (int i = 0; i < route.Count; i++)
                polyline.Points.Add(route[i]);
            items[0] = polyline;
            return new RequestCompletedEventArgs(items, null, false, null);
        }
        protected void RaiseChanged() {
            if (OnDataResponse != null)
                OnDataResponse(this, CreateEventArgs());
        }
        public void CalculateRoute(GeoPoint point1, GeoPoint point2) {
            CalculateRouteCore(point1, point2);
            RaiseChanged();
        }
        void CalculateRouteCore(GeoPoint point1, GeoPoint point2) {
            this.route.Clear();
            route.Add(point1);
            route.Add(point2);
        }
    }
}
