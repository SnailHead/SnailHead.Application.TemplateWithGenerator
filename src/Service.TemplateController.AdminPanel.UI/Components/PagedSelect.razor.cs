using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Service.TemplateController.AdminPanel.UI.Components;

public partial class PagedSelect<T>
{
    [Parameter]
    public Func<T?, Task>? OnValueSelected { get; set; }
    [Parameter, EditorRequired] public Func<PagedSelectParams, Task<List<T>>> ServerData { get; set; } = null!;
    [Parameter] public string Label { get; set; } = "";
    [Parameter] public string Placeholder { get; set; } = "";
    [Parameter] public bool Required { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public Func<T?, string>? ToStringFunc { get; set; }

    public T? SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value)
                return;
            _selectedValue = value;
            OnValueSelected?.Invoke(_selectedValue);
        }
    }

    private PagedSelectParams _params = new();

    private MudAutocomplete<T> _autocomplete = null!;
    private T? _selectedValue;

    public async Task ReloadAsync()
    {
        _params.PageIndex = 0;
        await _autocomplete.ClearAsync();
    }

    private async Task<IEnumerable<T>> HandleSearch(string query, CancellationToken cancellationToken)
    {
        _params.PageIndex = 0;
        _params.SearchQuery = query;
        var values = await ServerData.Invoke(_params);
        return values;
    }

    private async Task HandleNextPage()
    {
        _params.PageIndex++;
        //await _autocomplete.();
    }

    public class PagedSelectParams
    {
        public string? SearchQuery { get; set; } = string.Empty;
        public int PageIndex { get; set; }
        public CancellationToken CancellationToken { get; set; }
    }
}