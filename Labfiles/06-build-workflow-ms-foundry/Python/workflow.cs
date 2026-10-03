// dotnet add package Azure.AI.Projects --version 2.0.0-beta.1
using Azure.AI.Projects;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001

const string endpoint = "<YOUR_PROJECT_ENDPOINT>";
const string agentName = "ContosoPay-Customer-Support-Triage";
const string agentVersion = "3";
const string userMessage = "Hi ContosoPay-Customer-Support-Triage";

// Connect to your project using the endpoint from your project page
AIProjectClient projectClient = new(endpoint: new Uri(endpoint), tokenProvider: new DefaultAzureCredential());

ProjectConversation conversation = projectClient.OpenAI.Conversations.CreateProjectConversation();
AgentReference agentReference = new AgentReference(name: agentName, version: agentVersion);
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference, conversation.Id);

ResponseResult response = responseClient.CreateResponse(userMessage);
Console.WriteLine(response.GetOutputText());