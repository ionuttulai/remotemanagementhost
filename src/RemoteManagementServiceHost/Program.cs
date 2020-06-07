using Microsoft.AzureStack.Services.RemoteManagement.CoreLib;
using Microsoft.AzureStack.Services.RemoteManagement.CoreLib.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteManagementServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var cfg = new RemoteManagementServiceConfiguration()
                {
                    AzureConfig = new RemoteManagementServiceConfiguration.AzureConfiguration()
                    {
                        AzureRPEndpoint = "https://azstrptest002.trafficmanager.net",
                        CertificateThumbprint = "B151C58A6C3BFEE200C100F100E8D8492E171371",
                        ClientId = "66b2d367-a505-4a15-961e-6f36f829b327",
                        IsCertificatePinningEnabled = true,
                        LoginEndpoint = "https://login.microsoftonline.com/c4e29b3a-0a36-4da3-92b4-6f8f3762df27/",
                        Resource = "https://usage.microsoftazurestack.com",
                    },

                    AccessControlConfig = new Microsoft.AzureStack.Services.RemoteManagement.CoreLib.AccessControl.Configuration.AccessControlConfiguration()
                    {
                        DefaultAllowedSubsystem = "replication",
                        Enabled = false
                    },

                    DevicePropertiesServiceConfig = new RemoteManagementServiceConfiguration.DeviceConfiguration()
                    {
                        AdminPortalUri = "",
                        DeploymentId = ""
                    },

                    DeviceResourceManagerConfig = new RemoteManagementServiceConfiguration.DeviceResourceManagerConfiguration()
                    {
                        ArmBaseUri = "https://adminmanagement.local.azurestack.external/",
                        ClientId = "5ff9080f-6b7b-48da-882f-e6238cf49f24",
                        AadBaseUri = "https://login.microsoftonline.com/",
                        TenantDirectoryId = "73103a66-894e-4622-8ca7-da73c5c00c0b",
                        ArmResourceAadAudience = "https://adminmanagement.azurestackci03.onmicrosoft.com/d166836e-d12f-46e2-a209-7d749ec1c73e",
                        ValidateAuthority = true,
                        ApplicationAadCertificate = "3F3F221442AD23DA558075862789001CD48DD433",
                        RefreshAadTokenBefore = "00:00:15",
                        IdentitySystem = "AzureAD",
                        DeploymentVersion = "1.2005.0.20",
                        VersionRefreshInterval = "12:00:00"
                    },

                    ReplicationServiceConfig = new RemoteManagementServiceConfiguration.ReplicationServiceConfiguration()
                    {
                        AadTokenAudience = "https://usage.microsoftazurestack.com",
                        Enabled = true,
                        DefaultSubscriptionId = "f0afa71f-45a1-4bc2-aa46-f30cbfc9867d",
                        CacheRefreshInterval = TimeSpan.FromMinutes(10),
                        Location = "local",
                        ResourceProviderUri = "https://azstrptest002.trafficmanager.net/remotemanagement/snapshot",
                        UsageEndpointUri = ""
                    },

                    RunnerConfig = new Microsoft.AzureStack.Services.RemoteManagement.CoreLib.Configuration.Monitor.Configuration.RunnerConfiguration()
                    {
                        JobEnabled = true,
                        AlertMaxRetryCount = 10,
                        PollingInterval = TimeSpan.FromSeconds(30),
                        SubsystemName = "replication",
                        Timeout = TimeSpan.FromSeconds(25)
                    }
                };

                RemoteManagementService.Initialize(cfg);

                RemoteManagementService.Start();


                Thread.Sleep(2 * 60 * 1000);

                RemoteManagementService.Stop();

                Thread.Sleep(30 * 1000);

                RemoteManagementService.Start();

                while (true) { }

            }
            finally
            {
                RemoteManagementService.Stop();
            }

        }
    }
}
