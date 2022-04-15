using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorWASM.Client.Pages
{
    public partial class LifeCycle
    {
        public LifeCycle()
        {
            Console.WriteLine("Inside CTOR");
        }

        private int _counter;

        [Parameter]
        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                Console.WriteLine($"Counter set to {_counter}");
            }
        }

        private bool _firstParameterSet = true;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            Console.WriteLine("SetParamterAsync Called");
            if(parameters.TryGetValue(nameof(Counter), out int _counter))
            {
                //ignore odd values
                if(Counter % 2 == 0)
                {
                    return base.SetParametersAsync(parameters);
                }
                if (_firstParameterSet)
                {
                    _firstParameterSet = false;
                    StateHasChanged(); // force render
                }
            }

            return Task.CompletedTask;
        }

        DateTime lastUpdate;
        protected override void OnParametersSet()
        {
            lastUpdate = DateTime.Now;
            Console.WriteLine("OnParameterSet called");
        }

        DateTime created;
        protected override void OnInitialized()
        {
            created = DateTime.Now;
            Console.WriteLine("Onintialized called");
        }

        protected override void OnAfterRender(bool firstRender) => Console.WriteLine($"OnAfterRender called with firstRender = {firstRender}");

        protected override bool ShouldRender()
        {
            Console.WriteLine($"ShouldRender called");
            return true;
        }

        public void Dispose() => Console.WriteLine("Disposed");
    }
}
