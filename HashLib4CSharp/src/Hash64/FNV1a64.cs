/*
HashLib4CSharp Library
Copyright (c) 2020 Ugochukwu Mmaduekwe
GitHub Profile URL <https://github.com/Xor-el>

Distributed under the MIT software license, see the accompanying LICENSE file
or visit http://www.opensource.org/licenses/mit-license.php.

Acknowledgements:
This library was sponsored by Sphere 10 Software (https://www.sphere10.com)
for the purposes of supporting the XXX (https://YYY) project.
*/

using System;
using System.Diagnostics;
using HashLib4CSharp.Interfaces;

namespace HashLib4CSharp.Hash64
{
    internal sealed class FNV1a64 : FNV64
    {
        public override IHash Clone() => new FNV1a64 {Hash = Hash, BufferSize = BufferSize};

        public override void Initialize() => Hash = 14695981039346656037;

        public override void TransformBytes(byte[] data, int index, int length)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            Debug.Assert(index >= 0);
            Debug.Assert(length >= 0);
            Debug.Assert(index + length <= data.Length);
            var i = index;
            var hash = Hash;
            while (length > 0)
            {
                hash = (hash ^ data[i]) * 1099511628211;
                i++;
                length--;
            }

            Hash = hash;
        }
    }
}