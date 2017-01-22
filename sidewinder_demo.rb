require 'grid'
require 'sidewinder'

grid = Grid.new(4,4)
Sidewinder.on(grid)
puts grid
img = grid.to_png cell_size: 50
img.save "maze_sidewinder.png"