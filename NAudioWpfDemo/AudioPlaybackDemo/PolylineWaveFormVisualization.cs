using NAudio.Core.Dsp;

namespace NAudioWpfDemo.AudioPlaybackDemo
{
    class PolylineWaveFormVisualization : IVisualizationPlugin
    {
        private readonly PolylineWaveFormControl polylineWaveFormControl = new PolylineWaveFormControl();

        public string Name => "Polyline WaveForm Visualization";

        public object Content => polylineWaveFormControl;

        public void OnMaxCalculated(float min, float max)
        {
            polylineWaveFormControl.AddValue(max, min);
        }

        public void OnFftCalculated(Complex[] result)
        {
            // nothing to do
        }
    }
}
