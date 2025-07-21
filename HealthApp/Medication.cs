namespace HealthApp;

public class Medication : ContentPage
{
    public Medication()
    {
        var myGrid = new Grid();
        var columnSize = 2;

        var modals = new List<TempModal>{
            new TempModal("paras"),
            new TempModal("infliximab"),
            new TempModal("codine"),
            new TempModal("asprin"),
            new TempModal("ant-acids"),
            new TempModal("lanzoprazole"),
            new TempModal("esomeprazole"),
            new TempModal("citirizine"),
            new TempModal("loratadine"),
            new TempModal("fexofenadine"),
            new TempModal("Ibruprofen"),
            new TempModal("Certraline"),
            new TempModal("Atenolol"),
            new TempModal("Morphine")
        };

        var itemCounter = 0;
        var howWideTheColumnIs = DeviceDisplay.Current.MainDisplayInfo.Width / 125 * 100 / 2;

        for (var i = 0; i < columnSize; i++)
        {

            myGrid.AddColumnDefinition(new ColumnDefinition(howWideTheColumnIs));
        }

        for (var i = 0; i < (modals.Count % 2); i++)
        {
            myGrid.AddRowDefinition(new RowDefinition(DeviceDisplay.Current.MainDisplayInfo.Height - 60 / 4));

        }

        var row = 0;
        for (int i = 0; i < modals.Count; i++)
        {
            Button button = new();
            button.Text = modals[i].Name;
            button.WidthRequest = howWideTheColumnIs - 5;
            button.Padding = 5;
            button.Margin = 5;


            var column = 0;


            if (int.IsEvenInteger(i))
            {
                column = 0;
                myGrid.Add(button, column, row);
            }
            else
            {
                column = 1;
                myGrid.Add(button, column, row);
                row++;
            }
        }

        Content = new VerticalStackLayout
        {
            Children = {
                new Label{HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI in c#!" },
                myGrid
            }
        };
    }

    public class TempModal
    {
        public TempModal(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }


}