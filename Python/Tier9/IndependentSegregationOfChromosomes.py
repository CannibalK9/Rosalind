#http://rosalind.info/problems/indc/

import scipy.stats as ss
import numpy

n = int(open('C:\code\dataset.txt').read()) * 2

hh = ss.binom(n, 0.5)

p = []
total_p = 0
for k in range(0, n):
    total_p += hh.pmf(k)
    p.append("{0:.3f}".format(numpy.log10(total_p)))

p.reverse()

print " ".join(p)

          
