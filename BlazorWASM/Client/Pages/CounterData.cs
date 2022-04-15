using System;
namespace BlazorWASM.Client.Pages
{
    public class CounterData
    {
        private int _count;
        public int Count { get => this._count; set {
            if(value != _count)
                {
                    this._count = value;
                    CountChanged?.Invoke(this._count);
                }
            } }
        public Action<int>? CountChanged { get; set; }
    }
}
