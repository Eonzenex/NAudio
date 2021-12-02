using NAudio.Core.Dsp;

namespace NAudioWpfDemo.AudioPlaybackDemo
{
    class PolygonWaveFormVisualization : IVisualizationPlugin
    {
        private readonly PolygonWaveFormControl polygonWaveFormControl = new PolygonWaveFormControl();

        public string Name => "Polygon WaveForm Visualization";

        public object Content => polygonWaveFormControl;

        public void OnMaxCalculated(float min, float max)
        {
            polygonWaveFormControl.AddValue(max, min);
        }

        public void OnFftCalculated(Complex[] result)
        {
            // nothing to do
        }
    }
}
