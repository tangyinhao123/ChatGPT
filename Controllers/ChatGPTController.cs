using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGPT.Controllers
{
    public class ChatGPTController : Controller
    {
        [HttpPost]
        [Route("getGpt")]
        public IActionResult GetResult([FromBody] string prompt)
        {
            string apiKey = "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";
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt= prompt;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 4000;
            var result = openai.Completions.CreateCompletionsAsync(completionRequest);
            if(result != null)
            {
                foreach(var item in result.Result.Completions)
                {
                    answer+= item.Text; 
                }
                return Ok(answer);
            }
            else
            {
                return BadRequest("Not Find");
            }

        }
    }
}
