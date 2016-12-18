﻿//
// Navigator.cs
//
// Author:
//       Benito Palacios Sánchez <benito356@gmail.com>
//
// Copyright (c) 2016 Benito Palacios Sánchez
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
namespace Libgame.FileSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// FileSystem navigator.
    /// Search for nodes and iterate over them.
    /// </summary>
    /// <typeparam name="T">The implementation of NavegableNodes</typeparam>
    public class Navigator<T>
        where T : NavegableNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Libgame.FileSystem.Navigator`1"/> class.
        /// </summary>
        /// <param name="node">Initial node.</param>
        public Navigator(T node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            Node = node;
        }

        /// <summary>
        /// Gets the current node.
        /// </summary>
        /// <value>The node.</value>
        public T Node {
            get;
            private set;
        }

        /// <summary>
        /// Search a node by path.
        /// </summary>
        /// <param name="path">Path to search.</param>
        /// <returns>Node or null if not found.</returns>
        public T SearchFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (!path.StartsWith(Node.Path, StringComparison.InvariantCulture))
                return null;

            var queue = new Queue<T>();
            queue.Enqueue(Node);

            while (queue.Count > 0) {
                T currentNode = queue.Dequeue();
                if (path == currentNode.Path)
                    return currentNode;

                foreach (T child in currentNode.Children)
                    queue.Enqueue(child);
            }

            return null;
        }

        /// <summary>
        /// Iterates the nodes recursively.
        /// </summary>
        /// <returns>The nodes.</returns>
        public IEnumerable<T> IterateNodes()
        {
            var queue = new Queue<T>();
            queue.Enqueue(Node);

            while (queue.Count > 0) {
                T node = queue.Dequeue();

                foreach (var child in node.Children) {
                    queue.Enqueue(child);
                    yield return child;
                }
            }
        }
    }
}
