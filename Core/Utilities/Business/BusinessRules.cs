using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        
        public static async Task<IResult> RunAsync(params Task<IResult>[] logics)
        {
            var results = await Task.WhenAll(logics);

            foreach (var result in results)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            return new SuccessResult();
        }

    }
}