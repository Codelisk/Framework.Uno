public sealed partial class Shell : Page
{
    public Shell()
    {
        this
            .Content(new StackPanel()
            .VerticalAlignment(VerticalAlignment.Stretch)
            .HorizontalAlignment(HorizontalAlignment.Stretch)
            .Children(
                new Grid().HorizontalAlignment(HorizontalAlignment.Stretch).RowDefinitions("auto,*").ColumnDefinitions("*")
                .Children(
                    new ContentControl().VerticalAlignment(VerticalAlignment.Top).VerticalContentAlignment(VerticalAlignment.Top).HorizontalContentAlignment(HorizontalAlignment.Stretch).HorizontalAlignment(HorizontalAlignment.Stretch)
                    .Name("Header")
                    .RegionManager(regionName:"HeaderRegion"),
                    new ContentControl().HorizontalContentAlignment(HorizontalAlignment.Stretch).HorizontalAlignment(HorizontalAlignment.Stretch)
                    .Name("Body")
                    .RegionManager(regionName: "BodyRegion")
                    .Grid(row: 1)
            )));
    }
}
