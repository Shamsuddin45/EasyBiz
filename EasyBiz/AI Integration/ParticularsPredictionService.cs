using EasyBiz;
using EasyBiz.AI_Integration;

public class ParticularsPredictionService
{
    private readonly LocalHistoryPredictor _local = new();
    private readonly LlmParticularsPredictor _llm = new();

    public async Task<PredictionResult> PredictAsync(PredictionContext ctx)
    {
        var matches = _local.GetTopMatches(ctx);

        if (matches.Any() && matches[0].Count >= 2)
        {
            return new PredictionResult
            {
                Particulars = matches[0].Description,
                Source = "Local",
                AlternateSuggestions = matches.Skip(1).Select(m => m.Description).ToList()
            };
        }

        var llmResult = await _llm.PredictAsync(ctx, matches.Select(m => m.Description).ToList());

        return new PredictionResult
        {
            Particulars = llmResult ?? matches.FirstOrDefault().Description ?? "",
            Source = llmResult != null ? "LLM" : "Local",
            AlternateSuggestions = matches.Select(m => m.Description).ToList()
        };
    }
}