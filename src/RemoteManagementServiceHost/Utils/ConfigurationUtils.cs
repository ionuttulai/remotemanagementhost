using Microsoft.AzureStack.Services.RemoteManagement.CoreLib;
using Microsoft.AzureStack.Services.RemoteManagement.CoreLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RemoteManagementServiceHost.Utils
{
    public static class ConfigurationUtils
    {
        public static RemoteManagementServiceConfiguration GetLocalConfig()
        {
            var retValue = new RemoteManagementServiceConfiguration()
            {
                AzureConfig = new RemoteManagementServiceConfiguration.AzureConfiguration()
                {
                    DesiredStateEndpoint = "http://localhost:5000/remotemanagement/desiredstate",
                    ReplicationEndpoint = "http://localhost:5000/api/replication",
                    LoginEndpoint = "https://login.microsoftonline.com/418bfaa4-6f22-4142-92c3-82f1c2c00966",
                    CertificateThumbprint = "FF931689CCF5B421BF1D73661CE7CD629D3974A8",
                    ClientId = "505b5cb8-2c12-4158-b1a2-edb0088b6f02",
                    AzureRpResourceAudience = "https://management.azure.com/",
                    IsCertificatePinningEnabled = false,
                },

                DeviceConfig = new RemoteManagementServiceConfiguration.DeviceConfiguration()
                { 
                    ArmBaseUri = "http://localhost:5000/dummyarm/",
                    LoginEndpoint = "https://login.microsoftonline.com/418bfaa4-6f22-4142-92c3-82f1c2c00966",
                    CertificateThumbprint = "FF931689CCF5B421BF1D73661CE7CD629D3974A8",
                    ClientId = "505b5cb8-2c12-4158-b1a2-edb0088b6f02",
                    ArmResourceAudience = "https://management.azure.com/",
                    ValidateAuthority = false,
                    DefaultSubscriptionId = "c43cb968-d91d-4ce4-909e-b1848d107f91",
                    Location = "local",
                    DeploymentId = Guid.NewGuid().ToString(),
                    AdminPortalUri = "http://adminportal.azurestack.external",
                },

                ServiceConfig = new RemoteManagementServiceConfiguration.ServiceConfiguration()
                {
                    AccessControlConfig = new RemoteManagementServiceConfiguration.ServiceConfiguration.AccessControlConfiguration()
                    { 
                        DefaultAllowedSubsystem = "replication",
                        Enabled = false,
                    },

                    ConfigMonitorConfig = new RemoteManagementServiceConfiguration.ServiceConfiguration.ConfigurationMonitorConfiguration()
                    {
                        AlertMaxRetryCount = 5,
                        BasePermissionSubsystemName = "replication",
                        JobEnabled = true,
                        PollingInterval = TimeSpan.FromSeconds(30),
                        Timeout = TimeSpan.FromSeconds(25),
                    },

                    ReplicationConfig = new RemoteManagementServiceConfiguration.ServiceConfiguration.ReplicationConfiguration()
                    {
                        Enabled = true,
                        CacheRefreshInterval = TimeSpan.FromMinutes(1)
                    },
                    
                    IsRemoteManagementEnabled = true
                }
            };

            return retValue;
        }

        public static RemoteManagementServiceConfiguration GetTest002Config()
        {
            var retValue = new RemoteManagementServiceConfiguration()
            {
                AzureConfig = new RemoteManagementServiceConfiguration.AzureConfiguration()
                {
                    DesiredStateEndpoint = "https://azstrptest002.trafficmanager.net/remotemanagement/desiredstate",
                    ReplicationEndpoint = "https://azstrptest002.trafficmanager.net/remotemanagement/snapshot",
                    CertificateThumbprint = "B151C58A6C3BFEE200C100F100E8D8492E171371",
                    ClientId = "66b2d367-a505-4a15-961e-6f36f829b327",
                    IsCertificatePinningEnabled = false,
                    LoginEndpoint = "https://login.microsoftonline.com/c4e29b3a-0a36-4da3-92b4-6f8f3762df27/",
                    AzureRpResourceAudience = "https://usage.microsoftazurestack.com",
                    
                },

                DeviceConfig = new RemoteManagementServiceConfiguration.DeviceConfiguration()
                {
                    ArmBaseUri = "https://adminmanagement.local.azurestack.external/",
                    ClientId = "5ff9080f-6b7b-48da-882f-e6238cf49f24",
                    CertificateThumbprint = "3F3F221442AD23DA558075862789001CD48DD433",
                    ArmResourceAudience = "https://adminmanagement.azurestackci03.onmicrosoft.com/d166836e-d12f-46e2-a209-7d749ec1c73e",
                    DefaultSubscriptionId = "f0afa71f-45a1-4bc2-aa46-f30cbfc9867d",
                    LoginEndpoint = "https://login.microsoftonline.com/73103a66-894e-4622-8ca7-da73c5c00c0b", 
                    ValidateAuthority = false,
                    Location = "local",
                    DeploymentId = Guid.NewGuid().ToString(),
                    AdminPortalUri = "http://adminportal.azurestack.external",
                },

                ServiceConfig = new RemoteManagementServiceConfiguration.ServiceConfiguration()
                {
                    AccessControlConfig = new RemoteManagementServiceConfiguration.ServiceConfiguration.AccessControlConfiguration()
                    {
                        DefaultAllowedSubsystem = "replication",
                        Enabled = false,
                    },

                    ConfigMonitorConfig = new RemoteManagementServiceConfiguration.ServiceConfiguration.ConfigurationMonitorConfiguration()
                    {
                        AlertMaxRetryCount = 5,
                        BasePermissionSubsystemName = "replication",
                        JobEnabled = true,
                        PollingInterval = TimeSpan.FromSeconds(30),
                        Timeout = TimeSpan.FromSeconds(25),
                    },

                    ReplicationConfig = new RemoteManagementServiceConfiguration.ServiceConfiguration.ReplicationConfiguration()
                    {
                        Enabled = true,
                        CacheRefreshInterval = TimeSpan.FromMinutes(1)
                    },

                    IsRemoteManagementEnabled = true
                }
            };

            return retValue;
        }
    }
}
