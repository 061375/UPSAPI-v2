using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UPSAPIv2.Models;

namespace UPSAPIv2.api
{
    public class Label
    {
        private Models._Root ShipmentResponse;
        private Models.LabelRecoveryRequest request = new Models.LabelRecoveryRequest();
        private LabelParams labelParams;

        public List<string> TrackingNumbers = new List<string>();
        public List<string> Labels = new List<string>();
        public Dictionary<string, string> LabelData = new Dictionary<string, string>();

        /// <summary>
        /// convert the shipmentsd request into a JSON string
        /// </summary>
        /// <returns>string</returns>
        public string GetJson()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new IgnoreEmptyObjectContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(request, settings);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public bool GetProcessLabelResponse(string json)
        {
            if (!Response.Parse(json))
            {
                return false;
            }
            ShipmentResponse = Response.Get();
            foreach (Models.PackageResults p in ShipmentResponse.ShipmentResponse.ShipmentResults.PackageResults)
            {
                TrackingNumbers.Add(p.TrackingNumber);
                Labels.Add(p.ShippingLabel.GraphicImage);
                LabelData[p.TrackingNumber] = p.ShippingLabel.GraphicImage;
            }
            return true;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelParams"></param>
        /// <returns></returns>
        public bool RequestLabel(LabelParams labelParams)
        {
            if (!Validate()) { return false; }
            request.TrackingNumber = labelParams.TrackingNumber;
            request.MailInnovationsTrackingNumber = labelParams.MailInnovationsTrackingNumber;
            Request()
                .LabelSpecification()
                .LabelStockSize()
                .Translate()
                .LabelDelivery()
                .ReferenceValues()
                .UPSPremiumCareForm();
            return true;
        }
        private bool Validate()
        {
            // validate
            if (!Helpers.isnull(labelParams.SubVersion, Messages.Errors["required"], Params.RequestSubversion)) return false;
            if (labelParams.LabelStockSize)
            {
                if (labelParams.LabelStockSize_Height < 1) { Helpers.RecordError("LabelStockSize_Height must be greater than zero"); return false; }
                if (labelParams.LabelStockSize_Width < 1) { Helpers.RecordError("LabelStockSize_Width must be greater than zero"); return false; }
            }
            if (labelParams.Translate)
            {
                if (Helpers.isset(Validation.LanguageCode, labelParams.Translate_LanguageCode, Messages.Errors["notrec"])) return false;
                if (Helpers.isset(Validation.LanguageCode, labelParams.Translate_DialectCode, Messages.Errors["notrec"])) return false;
                if (Helpers.isset(Validation.LanguageCode, labelParams.Translate_Code, Messages.Errors["notrec"])) return false;
            }
            if (labelParams.ReferenceValues)
            {
                if (!Helpers.isnull(labelParams.ReferenceValues_ReferenceNumber_Value, Messages.Errors["requiredif"], "ReferenceValues")) return false;
                if (!Helpers.isnull(labelParams.ShipperNumber, Messages.Errors["requiredif"], "ReferenceValues")) return false;
            }
            if (labelParams.UPSPremiumCareForm)
            {
                if (!Helpers.isnull(labelParams.UPSPremiumCareForm_PageSize, Messages.Errors["requiredif"], "UPSPremiumCareForm")) return false;
                if (!Helpers.isnull(labelParams.UPSPremiumCareForm_PrintType, Messages.Errors["requiredif"], "UPSPremiumCareForm")) return false;
            }
            if (labelParams.LabelImageFormat)
            {
                if (Helpers.Contains(Validation.LabelImageFormat, Messages.Errors["notrec"], labelParams.LabelImageFormat_Code, "LabelImageFormat_Code")) return false;
            }
            // * validate
            return true;
        }
        private Label LabelStockSize()
        {
            request.LabelStockSize = new LabelStockSize();
            request.LabelStockSize.Width = labelParams.LabelStockSize_Width.ToString();
            request.LabelStockSize.Height = labelParams.LabelStockSize_Height.ToString();
            return this;
        }
        private Label Translate()
        {
            request.Translate = new Translate();
            request.Translate.LanguageCode = labelParams.Translate_LanguageCode;
            request.Translate.DialectCode = labelParams.Translate_DialectCode;
            request.Translate.Code = labelParams.Translate_Code;
            return this;
        }
        private Label LabelDelivery()
        {
            request.LabelDelivery = new LabelDelivery();
            request.LabelDelivery.LabelLinkIndicator = labelParams.LabelDelivery_LabelLinkIndicator;
            request.LabelDelivery.ResendEmailIndicator = labelParams.LabelDelivery_ResendEMailIndicator;
            return this;
        }
        private Label ReferenceValues()
        {
            request.ReferenceValues = new ReferenceValues();
            request.ReferenceValues.ReferenceNumber = new ReferenceNumber();
            request.ReferenceValues.ReferenceNumber.Value = labelParams.ReferenceValues_ReferenceNumber_Value;
            request.ReferenceValues.ShipperNumber = labelParams.ShipperNumber;
            return this;
        }
        private Label UPSPremiumCareForm()
        {
            request.Locale = labelParams.Locale;
            request.UPSPremiumCareForm = new UPSPremiumCareForm();
            request.UPSPremiumCareForm.PageSize = labelParams.UPSPremiumCareForm_PageSize;
            request.UPSPremiumCareForm.PrintType = labelParams.UPSPremiumCareForm_PrintType;
            return this;
        }
        private Label LabelSpecification()
        {
            request.LabelSpecification = new LabelSpecification();
            request.LabelSpecification.HTTPUserAgent = labelParams.HTTPUserAgent;
            request.LabelSpecification.LabelImageFormat = new LabelImageFormat();
            request.LabelSpecification.LabelImageFormat.Code = labelParams.LabelImageFormat_Code;
            request.LabelSpecification.LabelImageFormat.Description = labelParams.LabelImageFormat_Description;
            return this;
        }
        private Label Request()
        {
            request.Request = new Models.Request();
            request.Request.SubVersion = (labelParams.SubVersion != null ? Params.RequestSubversion : labelParams.SubVersion);
            request.Request.RequestOption = Params.RequestOption;
            request.Request.TransactionReference = new TransactionReference();
            request.Request.TransactionReference.CustomerContext = labelParams.CustomerContext;
            return this;
        }
    }
}