public sealed partial class Shell : Page
{
    public Shell()
    {
        try
        {
            this.Content(
                new Grid()
                    .HorizontalAlignment(HorizontalAlignment.Stretch)
                    .VerticalAlignment(VerticalAlignment.Stretch)
                    .RowDefinitions("auto,*")
                    .ColumnDefinitions("*")
                    .Margin(10)
                    .Children(
                        new ContentControl()
                            .VerticalAlignment(VerticalAlignment.Top)
                            .VerticalContentAlignment(VerticalAlignment.Top)
                            .HorizontalContentAlignment(HorizontalAlignment.Stretch)
                            .HorizontalAlignment(HorizontalAlignment.Stretch)
                            .Name("Header")
                            .RegionManager(regionName: "HeaderRegion"),
                        new ContentControl()
                            .VerticalAlignment(VerticalAlignment.Stretch)
                            .VerticalContentAlignment(VerticalAlignment.Stretch)
                            .HorizontalContentAlignment(HorizontalAlignment.Stretch)
                            .HorizontalAlignment(HorizontalAlignment.Stretch)
                            .Name("Body")
                            .RegionManager(regionName: "BodyRegion")
                            .Grid(row: 1)
                    )
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
