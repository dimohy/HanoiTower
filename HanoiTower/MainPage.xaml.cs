namespace HanoiTower;

public sealed partial class MainPage : Page
{
	private Tower[] _towers;

	public MainPage()
	{
		this.InitializeComponent();

		_towers = new Tower[]
		{
			t1, t2, t3
		};
	}

    private async void runButton_Click(object sender, RoutedEventArgs e)
    {
		runButton.IsEnabled = false;

		var size = (int)inputDiscs.Value;
		var delay = (int)inputDelay.Value;

        t1.DiscCount = size;
		t2.ClearDiscs();
        t3.ClearDiscs();

		await ProcessAsync(size, 0, 2);

		runButton.IsEnabled = true;

        async Task ProcessAsync(int size, int from, int to)
		{
			if (size is 0)
				return;

			var temp = 3 - (from + to);

			await ProcessAsync(size - 1, from, temp);
            await Task.Delay(delay);
            var num = _towers[from].PopDisc();
            _towers[to].PushDisc(num);
            await ProcessAsync(size - 1, temp, to);
		}
    }
}
