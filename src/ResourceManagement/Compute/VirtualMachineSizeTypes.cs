// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for VirtualMachineSizeTypes.
    /// </summary>
    public class VirtualMachineSizeTypes : ExpandableStringEnum<VirtualMachineSizeTypes>
    {
        /** Static value Basic_A0 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes BasicA0 = Parse("Basic_A0");

        /** Static value Basic_A1 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes BasicA1 = Parse("Basic_A1");

        /** Static value Basic_A2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes BasicA2 = Parse("Basic_A2");

        /** Static value Basic_A3 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes BasicA3 = Parse("Basic_A3");

        /** Static value Basic_A4 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes BasicA4 = Parse("Basic_A4");

        /** Static value Standard_A0 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA0 = Parse("Standard_A0");

        /** Static value Standard_A1 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA1 = Parse("Standard_A1");

        /** Static value Standard_A2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA2 = Parse("Standard_A2");

        /** Static value Standard_A3 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA3 = Parse("Standard_A3");

        /** Static value Standard_A4 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA4 = Parse("Standard_A4");

        /** Static value Standard_A5 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA5 = Parse("Standard_A5");

        /** Static value Standard_A6 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA6 = Parse("Standard_A6");

        /** Static value Standard_A7 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA7 = Parse("Standard_A7");

        /** Static value Standard_A8 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA8 = Parse("Standard_A8");

        /** Static value Standard_A9 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA9 = Parse("Standard_A9");

        /** Static value Standard_A10 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA10 = Parse("Standard_A10");

        /** Static value Standard_A11 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA11 = Parse("Standard_A11");

        /** Static value Standard_A1_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA1v2 = Parse("Standard_A1_v2");

        /** Static value Standard_A2_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA2v2 = Parse("Standard_A2_v2");

        /** Static value Standard_A4_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA4v2 = Parse("Standard_A4_v2");

        /** Static value Standard_A8_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA8v2 = Parse("Standard_A8_v2");

        /** Static value Standard_A2m_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA2mv2 = Parse("Standard_A2m_v2");

        /** Static value Standard_A4m_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA4mv2 = Parse("Standard_A4m_v2");

        /** Static value Standard_A8m_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardA8mv2 = Parse("Standard_A8m_v2");

        /** Static value Standard_D1 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD1 = Parse("Standard_D1");

        /** Static value Standard_D2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD2 = Parse("Standard_D2");

        /** Static value Standard_D3 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD3 = Parse("Standard_D3");

        /** Static value Standard_D4 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD4 = Parse("Standard_D4");

        /** Static value Standard_D11 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD11 = Parse("Standard_D11");

        /** Static value Standard_D12 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD12 = Parse("Standard_D12");

        /** Static value Standard_D13 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD13 = Parse("Standard_D13");

        /** Static value Standard_D14 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD14 = Parse("Standard_D14");

        /** Static value Standard_D1_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD1V2 = Parse("Standard_D1_v2");

        /** Static value Standard_D2_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD2V2 = Parse("Standard_D2_v2");

        /** Static value Standard_D3_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD3V2 = Parse("Standard_D3_v2");

        /** Static value Standard_D4_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD4V2 = Parse("Standard_D4_v2");

        /** Static value Standard_D5_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD5V2 = Parse("Standard_D5_v2");

        /** Static value Standard_D11_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD11V2 = Parse("Standard_D11_v2");

        /** Static value Standard_D12_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD12V2 = Parse("Standard_D12_v2");

        /** Static value Standard_D13_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD13V2 = Parse("Standard_D13_v2");

        /** Static value Standard_D14_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD14V2 = Parse("Standard_D14_v2");

        /** Static value Standard_D15_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardD15V2 = Parse("Standard_D15_v2");

        /** Static value Standard_DS1 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS1 = Parse("Standard_DS1");

        /** Static value Standard_DS2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS2 = Parse("Standard_DS2");

        /** Static value Standard_DS3 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS3 = Parse("Standard_DS3");

        /** Static value Standard_DS4 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS4 = Parse("Standard_DS4");

        /** Static value Standard_DS11 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS11 = Parse("Standard_DS11");

        /** Static value Standard_DS12 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS12 = Parse("Standard_DS12");

        /** Static value Standard_DS13 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS13 = Parse("Standard_DS13");

        /** Static value Standard_DS14 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS14 = Parse("Standard_DS14");

        /** Static value Standard_DS1_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS1V2 = Parse("Standard_DS1_v2");

        /** Static value Standard_DS2_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS2V2 = Parse("Standard_DS2_v2");

        /** Static value Standard_DS3_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS3V2 = Parse("Standard_DS3_v2");

        /** Static value Standard_DS4_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS4V2 = Parse("Standard_DS4_v2");

        /** Static value Standard_DS5_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS5V2 = Parse("Standard_DS5_v2");

        /** Static value Standard_DS11_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS11V2 = Parse("Standard_DS11_v2");

        /** Static value Standard_DS12_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS12V2 = Parse("Standard_DS12_v2");

        /** Static value Standard_DS13_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS13V2 = Parse("Standard_DS13_v2");

        /** Static value Standard_DS14_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS14V2 = Parse("Standard_DS14_v2");

        /** Static value Standard_DS15_v2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardDS15V2 = Parse("Standard_DS15_v2");

        /** Static value Standard_F1 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF1 = Parse("Standard_F1");

        /** Static value Standard_F2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF2 = Parse("Standard_F2");

        /** Static value Standard_F4 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF4 = Parse("Standard_F4");

        /** Static value Standard_F8 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF8 = Parse("Standard_F8");

        /** Static value Standard_F16 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF16 = Parse("Standard_F16");

        /** Static value Standard_F1s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF1s = Parse("Standard_F1s");

        /** Static value Standard_F2s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF2s = Parse("Standard_F2s");

        /** Static value Standard_F4s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF4s = Parse("Standard_F4s");

        /** Static value Standard_F8s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF8s = Parse("Standard_F8s");

        /** Static value Standard_F16s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardF16s = Parse("Standard_F16s");

        /** Static value Standard_G1 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardG1 = Parse("Standard_G1");

        /** Static value Standard_G2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardG2 = Parse("Standard_G2");

        /** Static value Standard_G3 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardG3 = Parse("Standard_G3");

        /** Static value Standard_G4 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardG4 = Parse("Standard_G4");

        /** Static value Standard_G5 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardG5 = Parse("Standard_G5");

        /** Static value Standard_GS1 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardGS1 = Parse("Standard_GS1");

        /** Static value Standard_GS2 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardGS2 = Parse("Standard_GS2");

        /** Static value Standard_GS3 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardGS3 = Parse("Standard_GS3");

        /** Static value Standard_GS4 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardGS4 = Parse("Standard_GS4");

        /** Static value Standard_GS5 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardGS5 = Parse("Standard_GS5");

        /** Static value Standard_H8 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardH8 = Parse("Standard_H8");

        /** Static value Standard_H16 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardH16 = Parse("Standard_H16");

        /** Static value Standard_H8m for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardH8m = Parse("Standard_H8m");

        /** Static value Standard_H16m for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardH16m = Parse("Standard_H16m");

        /** Static value Standard_H16r for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardH16r = Parse("Standard_H16r");

        /** Static value Standard_H16mr for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardH16mr = Parse("Standard_H16mr");

        /** Static value Standard_L4s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardL4s = Parse("Standard_L4s");

        /** Static value Standard_L8s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardL8s = Parse("Standard_L8s");

        /** Static value Standard_L16s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardL16s = Parse("Standard_L16s");

        /** Static value Standard_L32s for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardL32s = Parse("Standard_L32s");

        /** Static value Standard_NC6 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardNC6 = Parse("Standard_NC6");

        /** Static value Standard_NC12 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardNC12 = Parse("Standard_NC12");

        /** Static value Standard_NC24 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardNC24 = Parse("Standard_NC24");

        /** Static value Standard_NC24r for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardNC24r = Parse("Standard_NC24r");

        /** Static value Standard_NV6 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardNV6 = Parse("Standard_NV6");

        /** Static value Standard_NV12 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardNV12 = Parse("Standard_NV12");

        /** Static value Standard_NV24 for VirtualMachineSizeTypes. */
        public static readonly VirtualMachineSizeTypes StandardNV24 = Parse("Standard_NV24");

    }
}
