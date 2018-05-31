// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management.ContainerService.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerService.Fluent
{
    /// <summary>
    /// Defines values for VirtualMachineSizeTypes.
    /// </summary>
    public class ContainerServiceVirtualMachineSizeTypes : ExpandableStringEnum<ContainerServiceVirtualMachineSizeTypes>
    {
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA1 = Parse(ContainerServiceVMSizeTypes.StandardA1);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA2 = Parse(ContainerServiceVMSizeTypes.StandardA2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA3 = Parse(ContainerServiceVMSizeTypes.StandardA3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA4 = Parse(ContainerServiceVMSizeTypes.StandardA4);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA5 = Parse(ContainerServiceVMSizeTypes.StandardA5);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA6 = Parse(ContainerServiceVMSizeTypes.StandardA6);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA7 = Parse(ContainerServiceVMSizeTypes.StandardA7);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA8 = Parse(ContainerServiceVMSizeTypes.StandardA8);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA9 = Parse(ContainerServiceVMSizeTypes.StandardA9);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA10 = Parse(ContainerServiceVMSizeTypes.StandardA10);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA11 = Parse(ContainerServiceVMSizeTypes.StandardA11);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA1V2 = Parse(ContainerServiceVMSizeTypes.StandardA1V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA2V2 = Parse(ContainerServiceVMSizeTypes.StandardA2V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA2mV2 = Parse(ContainerServiceVMSizeTypes.StandardA2mV2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA4V2 = Parse(ContainerServiceVMSizeTypes.StandardA4V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA4mV2 = Parse(ContainerServiceVMSizeTypes.StandardA4mV2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA8V2 = Parse(ContainerServiceVMSizeTypes.StandardA8V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardA8mV2 = Parse(ContainerServiceVMSizeTypes.StandardA8mV2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD1 = Parse(ContainerServiceVMSizeTypes.StandardD1);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD2 = Parse(ContainerServiceVMSizeTypes.StandardD2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD3 = Parse(ContainerServiceVMSizeTypes.StandardD3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD4 = Parse(ContainerServiceVMSizeTypes.StandardD4);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD11 = Parse(ContainerServiceVMSizeTypes.StandardD11);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD12 = Parse(ContainerServiceVMSizeTypes.StandardD12);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD13 = Parse(ContainerServiceVMSizeTypes.StandardD13);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD14 = Parse(ContainerServiceVMSizeTypes.StandardD14);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD1V2 = Parse(ContainerServiceVMSizeTypes.StandardD1V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD2V2 = Parse(ContainerServiceVMSizeTypes.StandardD2V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD3V2 = Parse(ContainerServiceVMSizeTypes.StandardD3V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD4V2 = Parse(ContainerServiceVMSizeTypes.StandardD4V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD5V2 = Parse(ContainerServiceVMSizeTypes.StandardD5V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD11V2 = Parse(ContainerServiceVMSizeTypes.StandardD11V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD12V2 = Parse(ContainerServiceVMSizeTypes.StandardD12V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD13V2 = Parse(ContainerServiceVMSizeTypes.StandardD13V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD14V2 = Parse(ContainerServiceVMSizeTypes.StandardD14V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD15V2 = Parse(ContainerServiceVMSizeTypes.StandardD15V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD2V2Promo = Parse(ContainerServiceVMSizeTypes.StandardD2V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD3V2Promo = Parse(ContainerServiceVMSizeTypes.StandardD3V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD4V2Promo = Parse(ContainerServiceVMSizeTypes.StandardD4V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD5V2Promo = Parse(ContainerServiceVMSizeTypes.StandardD5V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD11V2Promo = Parse(ContainerServiceVMSizeTypes.StandardD11V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD12V2Promo = Parse(ContainerServiceVMSizeTypes.StandardD12V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD13V2Promo = Parse(ContainerServiceVMSizeTypes.StandardD13V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD14V2Promo = Parse(ContainerServiceVMSizeTypes.StandardD14V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD2V3 = Parse(ContainerServiceVMSizeTypes.StandardD2V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD4V3 = Parse(ContainerServiceVMSizeTypes.StandardD4V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD8V3 = Parse(ContainerServiceVMSizeTypes.StandardD8V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD16V3 = Parse(ContainerServiceVMSizeTypes.StandardD16V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD2sV3 = Parse(ContainerServiceVMSizeTypes.StandardD2sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD4sV3 = Parse(ContainerServiceVMSizeTypes.StandardD4sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD8sV3 = Parse(ContainerServiceVMSizeTypes.StandardD8sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardD16sV3 = Parse(ContainerServiceVMSizeTypes.StandardD16sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS1 = Parse(ContainerServiceVMSizeTypes.StandardDS1);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS15V2 = Parse(ContainerServiceVMSizeTypes.StandardDS15V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS2 = Parse(ContainerServiceVMSizeTypes.StandardDS2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS3 = Parse(ContainerServiceVMSizeTypes.StandardDS3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS4 = Parse(ContainerServiceVMSizeTypes.StandardDS4);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS11 = Parse(ContainerServiceVMSizeTypes.StandardDS11);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS12 = Parse(ContainerServiceVMSizeTypes.StandardDS12);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS13 = Parse(ContainerServiceVMSizeTypes.StandardDS13);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS14 = Parse(ContainerServiceVMSizeTypes.StandardDS14);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS1V2 = Parse(ContainerServiceVMSizeTypes.StandardDS1V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS2V2 = Parse(ContainerServiceVMSizeTypes.StandardDS2V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS3V2 = Parse(ContainerServiceVMSizeTypes.StandardDS3V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS4V2 = Parse(ContainerServiceVMSizeTypes.StandardDS4V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS5V2 = Parse(ContainerServiceVMSizeTypes.StandardDS5V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS11V2 = Parse(ContainerServiceVMSizeTypes.StandardDS11V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS12V2 = Parse(ContainerServiceVMSizeTypes.StandardDS12V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS13V2 = Parse(ContainerServiceVMSizeTypes.StandardDS13V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS14V2 = Parse(ContainerServiceVMSizeTypes.StandardDS14V2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS2V2Promo = Parse(ContainerServiceVMSizeTypes.StandardDS2V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS3V2Promo = Parse(ContainerServiceVMSizeTypes.StandardDS3V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS4V2Promo = Parse(ContainerServiceVMSizeTypes.StandardDS4V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS5V2Promo = Parse(ContainerServiceVMSizeTypes.StandardDS5V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS11V2Promo = Parse(ContainerServiceVMSizeTypes.StandardDS11V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS12V2Promo = Parse(ContainerServiceVMSizeTypes.StandardDS12V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS13V2Promo = Parse(ContainerServiceVMSizeTypes.StandardDS13V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardDS14V2Promo = Parse(ContainerServiceVMSizeTypes.StandardDS14V2Promo);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE2V3 = Parse(ContainerServiceVMSizeTypes.StandardE2V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE4V3 = Parse(ContainerServiceVMSizeTypes.StandardE4V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE8V3 = Parse(ContainerServiceVMSizeTypes.StandardE8V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE16V3 = Parse(ContainerServiceVMSizeTypes.StandardE16V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE32V3 = Parse(ContainerServiceVMSizeTypes.StandardE32V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE64V3 = Parse(ContainerServiceVMSizeTypes.StandardE64V3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE2sV3 = Parse(ContainerServiceVMSizeTypes.StandardE2sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE4sV3 = Parse(ContainerServiceVMSizeTypes.StandardE4sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE8sV3 = Parse(ContainerServiceVMSizeTypes.StandardE8sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE16sV3 = Parse(ContainerServiceVMSizeTypes.StandardE16sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE32sV3 = Parse(ContainerServiceVMSizeTypes.StandardE32sV3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardE64sV3 = Parse(ContainerServiceVMSizeTypes.StandardE64sV3);

        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF1 = Parse(ContainerServiceVMSizeTypes.StandardF1);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF2 = Parse(ContainerServiceVMSizeTypes.StandardF2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF4 = Parse(ContainerServiceVMSizeTypes.StandardF4);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF8 = Parse(ContainerServiceVMSizeTypes.StandardF8);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF16 = Parse(ContainerServiceVMSizeTypes.StandardF16);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF1s = Parse(ContainerServiceVMSizeTypes.StandardF1s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF2s = Parse(ContainerServiceVMSizeTypes.StandardF2s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF4s = Parse(ContainerServiceVMSizeTypes.StandardF4s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF8s = Parse(ContainerServiceVMSizeTypes.StandardF8s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardF16s = Parse(ContainerServiceVMSizeTypes.StandardF16s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardG1 = Parse(ContainerServiceVMSizeTypes.StandardG1);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardG2 = Parse(ContainerServiceVMSizeTypes.StandardG2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardG3 = Parse(ContainerServiceVMSizeTypes.StandardG3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardG4 = Parse(ContainerServiceVMSizeTypes.StandardG4);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardG5 = Parse(ContainerServiceVMSizeTypes.StandardG5);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardGS1 = Parse(ContainerServiceVMSizeTypes.StandardGS1);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardGS2 = Parse(ContainerServiceVMSizeTypes.StandardGS2);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardGS3 = Parse(ContainerServiceVMSizeTypes.StandardGS3);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardGS4 = Parse(ContainerServiceVMSizeTypes.StandardGS4);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardGS5 = Parse(ContainerServiceVMSizeTypes.StandardGS5);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardH8 = Parse(ContainerServiceVMSizeTypes.StandardH8);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardH16 = Parse(ContainerServiceVMSizeTypes.StandardH16);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardH8m = Parse(ContainerServiceVMSizeTypes.StandardH8m);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardH16m = Parse(ContainerServiceVMSizeTypes.StandardH16m);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardH16mr = Parse(ContainerServiceVMSizeTypes.StandardH16mr);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardH16r = Parse(ContainerServiceVMSizeTypes.StandardH16r);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardL4s = Parse(ContainerServiceVMSizeTypes.StandardL4s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardL8s = Parse(ContainerServiceVMSizeTypes.StandardL8s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardL16s = Parse(ContainerServiceVMSizeTypes.StandardL16s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardL32s = Parse(ContainerServiceVMSizeTypes.StandardL32s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardM64ms = Parse(ContainerServiceVMSizeTypes.StandardM64ms);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardM128s = Parse(ContainerServiceVMSizeTypes.StandardM128s);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardNC6 = Parse(ContainerServiceVMSizeTypes.StandardNC6);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardNC12 = Parse(ContainerServiceVMSizeTypes.StandardNC12);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardNC24 = Parse(ContainerServiceVMSizeTypes.StandardNC24);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardNC24r = Parse(ContainerServiceVMSizeTypes.StandardNC24r);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardNV6 = Parse(ContainerServiceVMSizeTypes.StandardNV6);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardNV12 = Parse(ContainerServiceVMSizeTypes.StandardNV12);
        public static readonly ContainerServiceVirtualMachineSizeTypes StandardNV24 = Parse(ContainerServiceVMSizeTypes.StandardNV24);
    }
}
