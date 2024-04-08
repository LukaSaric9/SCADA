using Common;
using Modbus.FunctionParameters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Modbus.ModbusFunctions
{
    /// <summary>
    /// Class containing logic for parsing and packing modbus read holding registers functions/requests.
    /// </summary>
    public class ReadHoldingRegistersFunction : ModbusFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadHoldingRegistersFunction"/> class.
        /// </summary>
        /// <param name="commandParameters">The modbus command parameters.</param>
        public ReadHoldingRegistersFunction(ModbusCommandParameters commandParameters) : base(commandParameters)
        {
            CheckArguments(MethodBase.GetCurrentMethod(), typeof(ModbusReadCommandParameters));
        }

        /// <inheritdoc />
        public override byte[] PackRequest()
        {
            //TO DO: IMPLEMENT
            byte[] request = new byte[12];

            request[0] = BitConverter.GetBytes(CommandParameters.TransactionId)[1];
            request[1] = BitConverter.GetBytes(CommandParameters.TransactionId)[0];
            request[2] = BitConverter.GetBytes(CommandParameters.ProtocolId)[1];
            request[3] = BitConverter.GetBytes(CommandParameters.ProtocolId)[0];
            request[4] = BitConverter.GetBytes(CommandParameters.Length)[1];
            request[5] = BitConverter.GetBytes(CommandParameters.Length)[0];
            request[6] = CommandParameters.UnitId;
            request[7] = CommandParameters.FunctionCode;
            request[8] = BitConverter.GetBytes(((ModbusReadCommandParameters)CommandParameters).StartAddress)[1];
            request[9] = BitConverter.GetBytes(((ModbusReadCommandParameters)CommandParameters).StartAddress)[0];
            request[10] = BitConverter.GetBytes(((ModbusReadCommandParameters)CommandParameters).Quantity)[1];
            request[11] = BitConverter.GetBytes(((ModbusReadCommandParameters)CommandParameters).Quantity)[0];

            return request;
        }

        /// <inheritdoc />
        public override Dictionary<Tuple<PointType, ushort>, ushort> ParseResponse(byte[] response)
        {
            //TO DO: IMPLEMENT
            Dictionary<Tuple<PointType, ushort>, ushort> dict = new Dictionary<Tuple<PointType, ushort>, ushort>();

            ushort startAddress = ((ModbusReadCommandParameters)this.CommandParameters).StartAddress;
            ushort value;

            for(int i = 0; i < response[8]; i += 2)
            {
                value = (ushort)IPAddress.NetworkToHostOrder((short)BitConverter.ToUInt16(response, 9 + i));
                Tuple<PointType, ushort> tuple = new Tuple<PointType, ushort>(PointType.ANALOG_OUTPUT, startAddress++);
                dict.Add(tuple, value);
            }
            
            return dict;
        }
    }
}