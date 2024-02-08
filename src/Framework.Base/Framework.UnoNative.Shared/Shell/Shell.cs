public sealed partial class Shell : Page
{
    public Shell()
    {
        this
            .Content(
                new Grid().HorizontalAlignment(HorizontalAlignment.Stretch).RowDefinitions("auto,*").ColumnDefinitions("*")
                .Children(
                    new ContentControl().VerticalAlignment(VerticalAlignment.Top).VerticalContentAlignment(VerticalAlignment.Top).HorizontalContentAlignment(HorizontalAlignment.Stretch).HorizontalAlignment(HorizontalAlignment.Stretch)
                    .Name("Header")
                    .Margin(0,0,0,5)
                    .RegionManager(regionName:"HeaderRegion"),
                    new ScrollViewer().Content(new ContentControl().HorizontalContentAlignment(HorizontalAlignment.Stretch).HorizontalAlignment(HorizontalAlignment.Stretch)
                    .Name("Body")
                    .RegionManager(regionName: "BodyRegion")
                    )
                    .Grid(row: 1)
            ));
    }
}
