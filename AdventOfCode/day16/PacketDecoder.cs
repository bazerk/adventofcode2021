using System.Text;

namespace AdventOfCode.day16; 

public static class PacketDecoder {

    public static string GetBitStream(string hexString) {
        var output = new StringBuilder(hexString.Length * 4);
        foreach (var ch in hexString) {
            var asInt = Convert.ToInt16(ch.ToString(), 16);
            var asStr = Convert.ToString(asInt, 2);
            while (asStr.Length < 4) {
                asStr = "0" + asStr;
            }
            output.Append(asStr);
        }

        return output.ToString();
    }

    public static Packet DecodeHexString(string hexString) {
        var bitstream = GetBitStream(hexString);
        var (packet, ix) = DecodeBitStream(bitstream);
        return packet;
    }

    private const int VersionLength = 3;
    private const int TypeLength = 3;

    private static (Packet, int) DecodeBitStream(string bitstream) {
        var ix = 0;
        
        var packetVersionStr = bitstream.Substring(ix, VersionLength);
        ix += VersionLength;
        var packetVersion = Convert.ToInt32(packetVersionStr, 2); 

        var packetTypeStr = bitstream.Substring(ix, TypeLength);
        ix += TypeLength;
        var packetType = Convert.ToInt32(packetTypeStr, 2);
        
        var packet = new Packet {
            Version = packetVersion,
            Type = packetType,
        };
        
        if (packetType == Packet.Literal) {
            var (val, endOfLiteral) = ParseLiteralValue(bitstream.Substring(ix));
            ix += endOfLiteral;
            packet.LiteralValue = val;
        } else {
            var lengthType = bitstream[ix];
            ix += 1;

            var bitsInLength = (lengthType == '0') ? 15 : 11;
            var lengthStr = bitstream.Substring(ix, bitsInLength);
            ix += bitsInLength;
            
            var lengthValue = Convert.ToInt32(lengthStr, 2);
            var currentLength = 0;
            while (currentLength < lengthValue) {
                var (child, endIx) = DecodeBitStream(bitstream.Substring(ix));
                packet.Children.Add(child);
                ix += endIx;
                if (lengthType == '0') {
                    currentLength += endIx;
                }
                else {
                    currentLength++;
                }
            }
        }
        return (packet, ix);
    }

    private static (long, int) ParseLiteralValue(string bitstream) {
        var ix = 0;
        var binaryString = "";
        var seenFinal = false;
        while (!seenFinal) {
            binaryString += bitstream.Substring(ix + 1, 4);
            if (bitstream[ix] == '0') {
                seenFinal = true;
            }
            ix += 5;    
        }

        return (Convert.ToInt64(binaryString, 2), ix);
    }
}