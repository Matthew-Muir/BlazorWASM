using Microsoft.AspNetCore.Components;
namespace BlazorWASM.Client.Pages
{
    public partial class Dismissable
    {
        private bool show;
        [Parameter]
        public bool Show
        {
            get => show; set
            {
                if (value != show)
                {
                    show = value;
                    ShowChanged?.InvokeAsync(show);
                }
            }
        }
        [Parameter]
        public EventCallback<bool>? ShowChanged { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;
        public void Dismiss() => Show = false;
    }
}