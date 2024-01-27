public sealed partial class Shell : Page
{
    public Shell()
    {
        this
            .Background(Theme.Brushes.Background.Default)
            .Content(new StackPanel()
            .VerticalAlignment(VerticalAlignment.Center)
            .HorizontalAlignment(HorizontalAlignment.Center)
            .Children(
                new Grid().RowDefinitions("*,*")
                .Children(
                    new ContentControl()
                    .Name("Header")
                    .RegionManager(regionName:"HeaderRegion"),
                    new ContentControl()
                    .Name("Body")
                    .RegionManager(regionName: "BodyRegion")
                    .Grid(row: 1)
            )));
    }
}
