# CI-CD-Azure-DevOps-Training

# Azure Portal Setup

## Create Resource Group
1. Open the Azure portal.
2. Navigate to "Resource groups" and select your subscription (e.g., MRU SD Worx Internal Apps).
3. Create a new resource group in the West Europe region.

## Resource Group Actions
4. Within the resource group:
   - Navigate to "Locks" and disable delete operations.
   - Set up governance policies under "Policies" based on company standards.

## Create Web App Service
5. In the Azure portal, search for "App Service."
6. Select "Web app" and create a new instance.

## Web App Configuration
7. Provide instance details:
   - Choose "Publish" as Code.
   - Select Runtime Stack as ".NET 8."
   - Choose OS as Windows.
   - Set the region to West Europe.

## Windows Plan
8. Create a new Windows Plan (e.g., D1) within the specified region.
   - Select the "Free" tier for the app service pricing plan.

# Azure DevOps - Continuous Deployment (CD)

9. Open Azure DevOps and go to the "Pipelines" section.
10. Create a new release pipeline.
11. Set up an empty job with a stage named "dev."
12. Add an artifact from the SDConnect project's default build pipeline.

## Agent Job Configuration
13. Configure the DEV agent job:
    - Choose the Azure Pipeline agent pool.
    - Specify the latest specifications.
    - Select the appropriate artifact.

## Azure Web App Deployment
14. Add an agent job for deploying to Azure Web App.
15. Configure the Azure Web App deployment:
    - Select the subscription (e.g., Internal Apps).
    - Choose the Web App with the specified details.
    - Specify the app name.
    - Provide the path to the ZIP file for deployment.
    - Set the deployment method to "Zip Deploy."

## Additional Configuration
16. Optionally, define variables as needed.
17. Enable the development badge for tracking.
18. Save the release configuration and create a new release.

    ## Live Deployment Website Project
     WEBSITE([ASP .NET WEB APP](https://tgapp6.azurewebsites.net/)https://tgapp6.azurewebsites.net/)
    - https://tgapp6.azurewebsites.net/
    - Successfully built Pipeline
    - Deploying Successfully First Web App using ASP .NET on Azure Platform
   
    -  ## Live localhost (https://localhost:7139/) Screenshot
   
    -  ![Screenshot 2023-11-17 103208](https://github.com/Abdurrahman-gurib/CI-CD-Azure-DevOps-Training/assets/63855517/38d8f416-1ca0-4a96-8180-98faffcd2509)

![Screenshot 2023-11-17 103534](https://github.com/Abdurrahman-gurib/CI-CD-Azure-DevOps-Training/assets/63855517/302a9ef4-9999-4fff-b29b-c14f370401d8)

