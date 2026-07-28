using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace EasyBiz
{
    public static class AiPredictionHelper
    {
        public static void AttachToButton(Button btnPredict, TextBox txtDescription, Func<PredictionContext> getContext)
        {
            btnPredict.Click += async (s, e) =>
            {
                btnPredict.Enabled = false;
                string originalText = btnPredict.Text;
                btnPredict.Text = "Predicting...";

                try
                {
                    var service = new ParticularsPredictionService();
                    var result = await service.PredictAsync(getContext());

                    if (!string.IsNullOrEmpty(result.Particulars))
                        txtDescription.Text = result.Particulars;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Prediction failed: {ex.Message}");
                }
                finally
                {
                    btnPredict.Text = originalText;
                    btnPredict.Enabled = true;
                }
            };
        }
    }
}