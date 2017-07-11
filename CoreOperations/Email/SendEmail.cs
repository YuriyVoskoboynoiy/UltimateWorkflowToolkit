﻿using System.Activities;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using UltimateWorkflowToolkit.Common;

namespace UltimateWorkflowToolkit.CoreOperations.Email
{
    public class SendEmail: CrmWorkflowBase
    {
        #region Inputs/Outputs

        [Input("Email")]
        [RequiredArgument]
        [ReferenceTarget("email")]
        public InArgument<EntityReference> Email { get; set; }

        #endregion Inputs/Outputs

        #region Overriddes

        protected override void ExecuteWorkflowLogic(CodeActivityContext executionContext, IWorkflowContext context, IOrganizationService service,
            IOrganizationService sysService)
        {
            service.Execute(new SendEmailRequest()
            {
                EmailId = Email.Get(executionContext).Id,
                IssueSend = true,
                TrackingToken = string.Empty
            });
        }

        #endregion Overriddes

    }
}
